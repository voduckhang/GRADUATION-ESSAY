using AspNetCoreHero.ToastNotification.Abstractions;
using LUANVANTOTNGHIEP_VODUCANKHANG.Extension;
using LUANVANTOTNGHIEP_VODUCANKHANG.Helper;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly qldtContext _context;

        public INotyfService _notyfService { get; }
        public AccountController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidatePhone(string Phone)
        {
            try
            {
                var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Sodienthoai.ToLower() == Phone.ToLower());
                if (khachhang != null)
                    return Json(data: "Số điện thoại:" + Phone + "Đã được sử dụng");
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateEmail(string Email)
        {
            try
            {
                var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
                if (khachhang != null)
                    return Json(data: "Số điện thoại:" + Email + "Đã được sử dụng");
                return Json(data: true);
            }
            catch
            {
                return Json(data: true);
            }
        }

        [Route("tai-khoan-cua-toi.html", Name = "Dashboard")]
        public IActionResult Dashboard()
        {


            var taikhoanID = HttpContext.Session.GetString("KhachhangId");
            if (taikhoanID != null)
            {

                var khachhang = _context.Khachhangs.AsNoTracking().Include(z => z.Trangthai).SingleOrDefault(x => x.KhachhangId == Convert.ToInt32(taikhoanID));
                if (khachhang != null)
                {
                    var lsdonhang = _context.Donhangs.AsNoTracking().
                        Include(x => x.Khachhang).Include(z => z.Trangthaidonhang).Include(u => u.Taikhoan).
                        Where(x => x.KhachhangId == khachhang.KhachhangId).
                        OrderByDescending(x => x.Ngaytaodon).Take(5).ToList();

                    ViewBag.DonHang = lsdonhang;
                    return View(khachhang);
                }
            }
            return RedirectToAction("Login");
        }

        [Route("chi-tiet-don-hang.html", Name = "Chitietdonhang")]
        public async Task<IActionResult> Chitietdonhang(int donhangID)
        {
            if (donhangID == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhangs
                .Include(d => d.Khachhang)
                .FirstOrDefaultAsync(m => m.DonhangId == donhangID);
            if (donhang == null)
            {
                return NotFound();
            }

            var chitietdonhang = _context.Chitietdonhangs.AsNoTracking().
                Include(x => x.Sanpham).Include(z => z.Sanpham.Hedieuhanh).
                Where(x => x.DonhangId == donhang.DonhangId).OrderBy(x => x.ChitietdonhangId).
                ToList();
            ViewBag.ChiTietDonHang = chitietdonhang;

            return View(donhang);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "DangKy")]
        public IActionResult Dangkytaikhoan()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "DangKy")]
        public async Task<IActionResult> Dangkytaikhoan(RegisterVM taikhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Khachhang khachhang = new Khachhang
                    {
                        Hovaten = taikhoan.FullName,
                        Sodienthoai = taikhoan.Phone.Trim().ToLower(),
                        Email = taikhoan.Email.Trim().ToLower(),
                        Matkhau = taikhoan.Password.Trim().ToMD5(),
                        Landangnhapgannhat = DateTime.Now,
                        TrangthaiId = true,
                        Diachi = taikhoan.DiaChi,
                        Ngaysinh = taikhoan.NgaySinh
                    };
                    try
                    {
                        _context.Add(khachhang);
                        await _context.SaveChangesAsync();
                        _notyfService.Success("Bạn đã đăng ký tài khoản thành công");
                        //lưu session makh
                        HttpContext.Session.SetString("KhachhangId", khachhang.KhachhangId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("KhachhangId");
                        //identity
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,khachhang.Hovaten),
                            new Claim("KhachhangId", khachhang.KhachhangId.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        return RedirectToAction("Dashboard", "Account");
                    }
                    catch
                    {
                        return RedirectToAction("Dangkytaikhoan", "Account");
                    }
                }
                else
                {
                    return View(taikhoan);
                }
            }
            catch
            {
                return View(taikhoan);
            }
        }

        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "DangNhap")]
        public IActionResult Login(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("KhachhangId");
            if (taikhoanID != null)
            {
                return RedirectToAction("Dashboard", "Account");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "DangNhap")]
        public async Task<IActionResult> Login(LoginViewModel customer, string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isEmail = Utilities.IsValidEmail(customer.UserName);
                    if (!isEmail) return View(customer);

                    var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == customer.UserName);

                    if (khachhang == null)
                    {
                        _notyfService.Success("Email chưa được đăng ký. Xin vui lòng đăng ký tài khoản mới!");
                        return RedirectToAction("Dangkytaikhoan");
                    }
                    if (khachhang.TrangthaiId == false)
                    {
                        _notyfService.Success("Tài Khoản của bạn đã bị vô hiệu hóa!");
                        return RedirectToAction("Login");
                    }

                    string pass = (customer.Password.Trim().ToMD5());
                    if (khachhang.Matkhau.Trim() != pass)
                    {
                        _notyfService.Success("Sai thông tin đăng nhập");
                        return View(customer);
                    }
                    khachhang.Landangnhapgannhat = DateTime.Now;
                    _context.Update(khachhang);
                    _context.SaveChanges();
                    HttpContext.Session.SetString("KhachhangId", khachhang.KhachhangId.ToString());
                    var taikhoanID = HttpContext.Session.GetString("KhachhangId");

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,khachhang.Hovaten),
                        new Claim("KhachhangId",khachhang.KhachhangId.ToString())
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    _notyfService.Success("Đăng nhập thành công");
                    return RedirectToAction("Dashboard", "Account");

                }
            }
            catch
            {
                return RedirectToAction("Dangkytaikhoan", "Account");
            }
            return View(customer);
        }
        //[HttpGet]
        //[Route("dang-xuat.html", Name = "Logout")]
        public IActionResult Logout(int ID)
        {

            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("KhachhangId");
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("change-password.html", Name = "ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var taikhoanID = HttpContext.Session.GetString("KhachhangId");
                    if (taikhoanID == null)
                    {
                        return RedirectToAction("Login", "Account");
                    }



                    var taikhoan = _context.Khachhangs.Find(Convert.ToInt32(taikhoanID));
                    if (taikhoan == null) return RedirectToAction("Login", "Account");

                    var pass = (model.PasswordNow.Trim()).ToMD5();
                    if (pass == taikhoan.Matkhau)
                    {
                        string passnew = (model.Password.Trim().ToMD5());
                        taikhoan.Matkhau = passnew;
                        _context.Update(taikhoan);
                        _context.SaveChanges();
                        _notyfService.Success("Thay doi mat khau thanh cong");
                        return RedirectToAction("Dashboard", "Account");
                    }
                }
            }
            catch
            {
                _notyfService.Success("Thay doi mat khau KHONG thanh cong");
                return RedirectToAction("Dashboard", "Account");
            }
            _notyfService.Success("Thay doi mat khau KHONG thanh cong");
            return RedirectToAction("Dashboard", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var taikhoan = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.Email.Trim() == model.Email);
                    if (taikhoan == null)
                    {
                        _notyfService.Success("Email không tồn tại, Xin vui lòng đăng ký tài khoản");
                        return RedirectToAction("Dangkytaikhoan", "Account");
                    }

                    string passnew = Utilities.GetRandomResetPassword();
                    try
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(@"khangvo37@gmail.com");
                        mail.To.Add(model.Email);
                        mail.Subject = "Khôi Phục Mật Khẩu";
                        mail.IsBodyHtml = true;
                        string content_3 = "Mật Khẩu Mới Của Bạn Là: " + passnew + "<br>";                                          
                        mail.Body = content_3;

                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                        smtpClient.UseDefaultCredentials = false;
                        NetworkCredential networkCredential = new NetworkCredential(@"khangvo37@gmail.com", "usqrmslzgdyhfqry");

                        smtpClient.Credentials = networkCredential;
                        smtpClient.Port = 587;
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mail);
                        ViewBag.Message = "Chúng tôi đã gửi mật khẩu khôi phục qua email. Xin vui lòng check email để đăng nhập. Cảm Ơn!";
                        ModelState.Clear();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = ex.Message.ToString();
                    }

                    taikhoan.Matkhau = passnew.ToMD5();

                    _context.Update(taikhoan);
                    _context.SaveChanges();
                    _notyfService.Success("Khôi phục mật khẩu thành công!");
                    return RedirectToAction("ForgotPassword", "Account");

                }
            }
            catch
            {
                _notyfService.Success("Thay doi mat khau KHONG thanh cong");
                return RedirectToAction("Dashboard", "Account");
            }
            _notyfService.Success("Thay doi mat khau KHONG thanh cong");
            return RedirectToAction("Dashboard", "Account");
        }
        /// <summary>
        /// ///////
        /// </summary>
        /// <returns></returns>
        ///         // GET: Admin/AdminKhachhangs/Edit/5
        public async Task<IActionResult> EditForCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            ViewData["TrangthaiId"] = new SelectList(_context.Trangthais, "TrangthaiId", "TrangthaiId", khachhang.TrangthaiId);
            return View(khachhang);
        }

        // POST: Admin/AdminKhachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditForCustomer(int id, [Bind("KhachhangId,Hovaten,Ngaysinh,Diachi,Email,Sodienthoai,Landangnhapgannhat,Matkhau,TrangthaiId")] Khachhang khachhang)
        {
            if (id != khachhang.KhachhangId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Bạn Đã Cập Nhật Thông Tin Khách Hàng Thành Công!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Dashboard");
            }
            ViewData["TrangthaiId"] = new SelectList(_context.Trangthais, "TrangthaiId", "TrangthaiId", khachhang.TrangthaiId);
            return View(khachhang);
        }

    }
}
