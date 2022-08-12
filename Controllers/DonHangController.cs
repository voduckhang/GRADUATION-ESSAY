using AspNetCoreHero.ToastNotification.Abstractions;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Controllers
{
    public class DonHangController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfService { get; }
        public DonHangController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

       [HttpPost]
        public async Task<IActionResult> DetailsOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var taikhoanID = HttpContext.Session.GetString("KhachhangId");
                if (string.IsNullOrEmpty(taikhoanID)) return RedirectToAction("Login", "Account");
                var khachhang = _context.Khachhangs.AsNoTracking().SingleOrDefault(x => x.KhachhangId == Convert.ToInt32(taikhoanID));
                if (khachhang == null) return NotFound();
                var donhang = await _context.Donhangs.
                    FirstOrDefaultAsync(m => m.DonhangId == id && Convert.ToInt32(taikhoanID) == m.KhachhangId);
                if (donhang == null)
                {
                    return NotFound();
                }
                var chitietdonhang = _context.Chitietdonhangs.Include(x => x.Sanpham).AsNoTracking().
                    Where(x => x.DonhangId == id).OrderBy(x => x.ChitietdonhangId).ToList();
                XemDonHang donHang = new XemDonHang();
                donHang.DonHang = donhang;
                donHang.ChiTietDonHang = chitietdonhang;
                return PartialView("DetailsOrder", donHang);
                //return RedirectToAction("Details", "DonHang");
            }
            catch
            {
                return NotFound();
            }

        }
    }
}
