using AspNetCoreHero.ToastNotification.Abstractions;
using LUANVANTOTNGHIEP_VODUCANKHANG.Extension;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfService { get; }
        public HomeController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("login-admin.html", Name = "LoginAdmin")]
        public IActionResult LoginAdmin()
        {

            return View();
        }

        [HttpPost]
        [Route("login-admin.html", Name = "LoginAdmin")]
        public async Task<IActionResult> LoginAdmin(/*LoginAdminViewModel customer*/string Username, string Matkhau, string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //if(acc.chucvu==nhanvien)
                    var acc = _context.Nhanviens.AsTracking().SingleOrDefault(x => x.Username == Username);
                    var accadmin = _context.AdminManagers.AsTracking().SingleOrDefault(x => x.TenAdmin == Username);
                    ViewBag.accadminmanager = accadmin;
                    if (acc == null && accadmin == null)
                    {
                        _notyfService.Success("Tài Khoản của bạn không tồn tại!");
                        return View();
                    }
                    if (acc != null && acc.PhanquyenId == 2)
                    {
                        if (acc.Matkhau != Matkhau.ToMD5())
                        {
                            _notyfService.Success("Sai Thông Tin Đăng Nhập");
                            return View(acc);
                        }
                        HttpContext.Session.SetString("TaikhoanID", acc.TaikhoanId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("TaikhoanID");
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,acc.Hovaten),
                        new Claim("TaikhoanID",acc.TaikhoanId.ToString())
                    };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng nhập thành công");

                        return RedirectToAction("Index", "AdminDonhangs");
                    }
                    //Dành cho đăng nhập Admin
                    if (accadmin != null && accadmin.PhanquyenId == 3)
                    {
                        if (accadmin.MatkhauAdmin != Matkhau.ToMD5())
                        {
                            _notyfService.Success("Sai Thông Tin Đăng Nhập");
                            return View(acc);
                        }
                        HttpContext.Session.SetString("AdminID", accadmin.AdminId.ToString());
                        var taikhoanID = HttpContext.Session.GetString("AdminID");
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,accadmin.TenAdmin),
                        new Claim("AdminID",accadmin.TenAdmin.ToString())
                    };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);
                        _notyfService.Success("Đăng nhập thành công");

                        return RedirectToAction("Index", "AdminNhanviens");
                    }
                }
            }
            catch
            {
                return View();
            }
            return View();
        }


        //[Route("dang-xuat.html", Name = "LogoutAdmin")]
        //[ActionName("Logout_Admin")]
        public IActionResult Logout_Admin(int ID)
        {
          
                HttpContext.SignOutAsync();
                HttpContext.Session.Remove("TaikhoanID");
                return RedirectToAction("Index", "AdminDonhangs");
        }
    }
}
