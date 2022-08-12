using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using PagedList.Core;
using AspNetCoreHero.ToastNotification.Abstractions;
using LUANVANTOTNGHIEP_VODUCANKHANG.Extension;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminKhachhangsController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfservice { get; }
        public AdminKhachhangsController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfservice = notyfService;
        }

        // GET: Admin/AdminKhachhangs
        public IActionResult Index(int? page, string searchKhachhang = "")
        {
            if (searchKhachhang != "" && searchKhachhang != null)
            {
                var pnumber = page == null || page <= 0 ? 1 : page.Value;
                var psize = 10;

                var lskhachhang = _context.Khachhangs.AsNoTracking().
                    Where(p => p.Hovaten.Contains(searchKhachhang))
                    .OrderByDescending(x => x.KhachhangId);
                PagedList<Khachhang> model = new PagedList<Khachhang>(lskhachhang, pnumber, psize);
                ViewBag.CurrentPage = pnumber;
                return View(model);
            }
            var pagenumber = page == null || page <= 0 ? 1 : page.Value;
            var pagesize = 10;
            var dskhachhang = _context.Khachhangs.AsNoTracking().OrderByDescending(x => x.KhachhangId);
            PagedList<Khachhang> models = new PagedList<Khachhang>(dskhachhang, pagenumber, pagesize);
            ViewBag.CurrentPage = pagenumber;
            return View(models);
        }

        // GET: Admin/AdminKhachhangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs
                .Include(k => k.Trangthai)
                .FirstOrDefaultAsync(m => m.KhachhangId == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // GET: Admin/AdminKhachhangs/Create
        public IActionResult Create()
        {
            ViewData["TrangthaiId"] = new SelectList(_context.Trangthais, "TrangthaiId", "TrangthaiId");
            return View();
        }

        // POST: Admin/AdminKhachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KhachhangId,Hovaten,Ngaysinh,Diachi,Email,Sodienthoai,Landangnhapgannhat,Matkhau,TrangthaiId")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrangthaiId"] = new SelectList(_context.Trangthais, "TrangthaiId", "TrangthaiId", khachhang.TrangthaiId);
            return View(khachhang);
        }

        // GET: Admin/AdminKhachhangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("KhachhangId,Hovaten,Ngaysinh,Diachi,Email,Sodienthoai,Landangnhapgannhat,Matkhau,TrangthaiId")] Khachhang khachhang)
        {
            if (id != khachhang.KhachhangId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    khachhang.Matkhau = khachhang.Matkhau.ToMD5();
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                    _notyfservice.Success("Bạn Đã Cập Nhật Thông Tin Khách Hàng Thành Công!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachhangExists(khachhang.KhachhangId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrangthaiId"] = new SelectList(_context.Trangthais, "TrangthaiId", "TrangthaiId", khachhang.TrangthaiId);
            return View(khachhang);
        }

        // GET: Admin/AdminKhachhangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhangs
                .Include(k => k.Trangthai)
                .FirstOrDefaultAsync(m => m.KhachhangId == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: Admin/AdminKhachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khachhang = await _context.Khachhangs.FindAsync(id);
            _context.Khachhangs.Remove(khachhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(int id)
        {
            return _context.Khachhangs.Any(e => e.KhachhangId == id);
        }
    }
}
