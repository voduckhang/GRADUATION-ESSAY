using AspNetCoreHero.ToastNotification.Abstractions;
using LUANVANTOTNGHIEP_VODUCANKHANG.Extension;
using LUANVANTOTNGHIEP_VODUCANKHANG.Helper;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfService { get; }
        public CheckoutController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(/*string returnUrl = null*/)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("KhachhangId");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                var khachhang = _context.Khachhangs.AsNoTracking().
                    SingleOrDefault(x => x.KhachhangId == Convert.ToInt32(taikhoanID));
                model.KhachhangId = khachhang.KhachhangId;
                model.FullName = khachhang.Hovaten;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Sodienthoai;
                model.Address = khachhang.Diachi;
            }

            ViewBag.GioHang = cart;
            return View(model);
        }

        [HttpPost]
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(MuaHangVM muaHang)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("KhachhangId");
            var khachhang = _context.Khachhangs.AsNoTracking().
                   SingleOrDefault(x => x.KhachhangId == Convert.ToInt32(taikhoanID));
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                //var khachhang = _context.Khachhangs.AsNoTracking().
                //    SingleOrDefault(x => x.KhachhangId == Convert.ToInt32(taikhoanID));
                model.KhachhangId = khachhang.KhachhangId;
                model.FullName = khachhang.Hovaten;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Sodienthoai;
                model.Address = khachhang.Diachi;

                _context.Update(khachhang);
                _context.SaveChanges();
            }
            try
            {
                //if (ModelState.IsValid)
                //{
                Donhang donhang = new Donhang();
                donhang.KhachhangId = model.KhachhangId;
                donhang.Diachigiaohang = muaHang.Address;
                donhang.Ngaytaodon = DateTime.Now;
                donhang.Tongtien = Convert.ToInt32(cart.Sum(x => x.TotalMoney));
                donhang.Masodonhang = Utilities.GetRandomIdNumberOrder();
                donhang.TrangthaidonhangId = 2;
                donhang.TaikhoanId = 10;
                _context.Add(donhang);
                //_context.SaveChanges();

                //lưu cái đơn hàng này vào chi tiết đơn hàng

                foreach (var item in cart)
                {
                    Chitietdonhang chitietdonhang = new Chitietdonhang();
                    chitietdonhang.ChitietdonhangId = donhang.DonhangId;
                    chitietdonhang.SanphamId = item.product.SanphamId;
                    chitietdonhang.Soluong = item.amount;
                    chitietdonhang.Tongtien = donhang.Tongtien;
                    chitietdonhang.GiaTien = item.product.Giatien;
                    chitietdonhang.Ngaylaphoadon = DateTime.Now;//đổi kiểu dữ liệu trong này thành datime
                    /* var sanpham=_context.Sanphams.AsNoTracking().Where(x=>x.SanphamId==item.product.Tonkho)     */
                    //_context.Add(chitietdonhang)
                    donhang.Chitietdonhangs.Add(chitietdonhang);
                }
               
                //gui hoa don qua email, xac nhan mua hang thanh cong
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(@"khangvo37@gmail.com");
                mail.To.Add(khachhang.Email);
                mail.Subject = "Hóa Đơn Mới #" + donhang.Masodonhang;
                mail.IsBodyHtml = true;

                string content_1 = "<h2>ĐƠN HÀNG #" + donhang.Masodonhang + "</h2>" +
                                   "<h4> Họ Và Tên:" + khachhang.Hovaten + "</h4>" +
                                   "<h4> Địa Chỉ:" + donhang.Diachigiaohang + "</h4>" +
                                   "<h4>Tổng Tiền:" + string.Format("{0:0,0 VNĐ}", donhang.Tongtien) + "</h4>";
                string total = "";
                string one = @"<!DOCTYPE html>
                                <html>
                                <style>
                                table, th, td {
                                  border:2px solid black;
                                }
                                </style>
                                <body>
                                <h2>Cảm Ơn Vì Đã Mua Hàng 😍  </h2>
                                <table style=""width: 100%;border:2px solid black; "">
                                  <tr>
                                     <th colspan = ""3"" style=""border: 2px solid black;""> OGANI </th>   
                                        </tr>     
                                        <tr>     
                                          <th style=""border: 2px solid black;""> Họ và tên: " + khachhang.Hovaten + "</th>" +
                                             @"<th style=""border: 2px solid black;""> Mã hóa đơn #" + donhang.Masodonhang + "</th>" +
                                         @"<th style=""border: 2px solid black;"">Ngày xuất hóa đơn:" + donhang.Ngaytaodon + "</th>" +
                                  "</tr>";
                total += one;
              foreach(var item in cart)
                            {
                                   string two = @"<tr>
                                        <th colspan=""2""  style=""border: 2px solid black;"">" + item.product.Tensanpham + "</th>" +
                                        @"<th  style=""border: 2px solid black;"">" + string.Format("{0:0,0 VNĐ}", item.product.Giatien) + "</th>" +
                                  "</tr>";
                    total += two;
                            }
                string three = @"
                             <tr>
                                <th colspan = ""3"" style = ""text-align:right;border: 2px solid black;""> Tổng tiền: " + string.Format("{0:0,0 VNĐ}", donhang.Tongtien) + "</ th >" +

                            "</tr>" +

                            "<tr>"+

                            @"<th colspan =""3"" style = ""text-align:right;border: 2px solid black;""> Địa chỉ giao hàng:" + donhang.Diachigiaohang +"</th>"+
              
                            "</tr>"+
              
                             "<tr>"+

                                @"<th colspan=""3"" style = ""text-align:left;border: 2px solid black;"" >Lưu ý:</th>" +
                     
                             "</tr>"+
                     "</table>"+                  
                     "</body>"+
                     "</html>";
                total += three;
                mail.Body =total;          
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.UseDefaultCredentials = false;
                NetworkCredential networkCredential = new NetworkCredential(@"khangvo37@gmail.com", "usqrmslzgdyhfqry");

                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
                ModelState.Clear();

                _notyfService.Success("Bạn đã đặt hàng thành công");
                _context.SaveChanges();
                HttpContext.Session.Remove("GioHang");

                return RedirectToAction("Success");
                //}
            }
            catch (Exception ex)
            {
                _notyfService.Success("Đặt hàng không thành công. Xin vui lòng thử lại!");
                ViewBag.GioHang = cart;
                return View(model);
            }
            ViewBag.GioHang = cart;
            return View(model);

        }
        [Route("dat-hang-thanh-cong.html", Name = "Success")]
        public IActionResult Success()
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("KhachhangId");
                if (string.IsNullOrEmpty(taikhoanID))
                {
                    _notyfService.Success("Đặt Hàng Thất Bại! Xin vui lòng kiểm tra lại.");
                    return RedirectToAction("Login", "Account", new { returnUrl = "/dat-hang-thanh-cong.html" });
                }
                var khachhang = _context.Khachhangs.AsNoTracking().
                    SingleOrDefault(x => x.KhachhangId == Convert.ToInt32(taikhoanID));
                var donhang = _context.Donhangs.
                    Where(x => x.KhachhangId == Convert.ToInt32(taikhoanID)).OrderByDescending(x => x.Ngaytaodon);
                MuaHangSuccessVM muaHangSuccess = new MuaHangSuccessVM();
                muaHangSuccess.FullName = khachhang.Hovaten;
                muaHangSuccess.Phone = khachhang.Sodienthoai;
                muaHangSuccess.Address = khachhang.Diachi;
                return View(muaHangSuccess);
            }
            catch
            {
                return View();
            }

        }
    }
}
