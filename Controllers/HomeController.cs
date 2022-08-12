using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using MimeKit;
using MailKit.Security;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly qldtContext _context;
        public INotyfService _notyfservice { get; }
        public HomeController( qldtContext context, INotyfService notyfService)
        {
           
            _context = context;
            _notyfservice = notyfService;
        }

        public IActionResult Index()
        {
            HomeViewModels models = new HomeViewModels();



            var lsproduct = _context.Sanphams.AsNoTracking().
                OrderByDescending(x => x.SanphamId).Take(4).ToList();

            List<ProductHomeViewModels> lsproductviews = new List<ProductHomeViewModels>();
            var lscats = _context.Danhmucs.AsNoTracking().
                OrderByDescending(x => x.DanhmucId).ToList();

            foreach (var item in lscats)
            {
                ProductHomeViewModels productHome = new ProductHomeViewModels();
                productHome.danhmuc = item;
                productHome.dssanpham = lsproduct.Where(x => x.DanhmucId == item.DanhmucId).ToList();
                lsproductviews.Add(productHome);
            }

            var tintuc = _context.Tintucs.AsNoTracking().OrderByDescending(x => x.TintucId).
                Take(3).ToList();


            models.products = lsproductviews;
            models.tintucs = tintuc;
            ViewBag.AllCategory = lscats;
            ViewBag.Allproduct = lsproduct;
            ViewBag.AllBlog = tintuc;
            return View(models);
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(SendMailDTO sendMailDto)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(@"khangvo37@gmail.com");
                mail.To.Add(@"voducankhang@gmail.com");
                mail.Subject = sendMailDto.Subject;
                mail.IsBodyHtml = true;
                string content_3 = "Mã Đơn Hàng:" + sendMailDto.Masodonhang + "<br>";
                string content_1 = "From Email:" + sendMailDto.Email + "<br>";
                string content = "Name:" + sendMailDto.Name + "<br>";
                string content_2 = "<br> Phone Number:" + sendMailDto.PhoneNumber + "<br>";
                content_1 += content + content_2 + content_3 + "<br> Massage:" + sendMailDto.Massage;
                mail.Body = content_1;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.UseDefaultCredentials = false;
                NetworkCredential networkCredential = new NetworkCredential(@"khangvo37@gmail.com", "usqrmslzgdyhfqry");

                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
                ViewBag.Message = "Chúng tôi đã nhận được phản hồi và sẽ liên hệ với bạn sớm nhất có thể. Xin Cảm Ơn!";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
