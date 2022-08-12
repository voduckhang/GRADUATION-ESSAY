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

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDonhangsController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfservice { get; }
        public AdminDonhangsController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfservice = notyfService;
        }

        // GET: Admin/AdminDonhangs
        //public async Task<IActionResult> Index()
        //{
        //    var qldtContext = _context.Donhangs.Include(d => d.Khachhang);
        //    return View(await qldtContext.ToListAsync());
        //}

        public IActionResult Index(int? page, string searchDonhang="")
        {
            if (searchDonhang != "" && searchDonhang != null)
            {
                var pnumber = page == null || page <= 0 ? 1 : page.Value;
                var psize = 10;
                var lsdonhang = _context.Donhangs.Include(d => d.Khachhang).Include(e=>e.Trangthaidonhang).
                    AsNoTracking().
                    Where(p=>p.Khachhang.Hovaten.Contains(searchDonhang))
                    .OrderByDescending(x => x.Ngaytaodon);
                PagedList<Donhang> model = new PagedList<Donhang>(lsdonhang, pnumber, psize);
                ViewBag.CurrentPage = pnumber;
                return View(model);
            }
            var pagenumber = page == null || page <= 0 ? 1 : page.Value;
            var pagesize = 10;
            var dsdonhang = _context.Donhangs.Include(d => d.Khachhang).Include(e => e.Trangthaidonhang).
                AsNoTracking().OrderByDescending(x => x.Ngaytaodon);
            PagedList<Donhang> models = new PagedList<Donhang>(dsdonhang, pagenumber, pagesize);
            ViewBag.CurrentPage = pagenumber;
            return View(models);
        }
        // GET: Admin/AdminDonhangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhangs
                .Include(d => d.Khachhang)
                .FirstOrDefaultAsync(m => m.DonhangId == id);
            if (donhang == null)
            {
                return NotFound();
            }

            var chitietdonhang = _context.Chitietdonhangs.AsNoTracking().
                Include(x=>x.Sanpham).
                Where(x => x.DonhangId == donhang.DonhangId).OrderBy(x => x.ChitietdonhangId).
                ToList();
            ViewBag.ChiTietDH = chitietdonhang;

            return View(donhang);
        }

        // GET: Admin/AdminDonhangs/Create
        public IActionResult Create()
        {
            ViewData["KhachhangId"] = new SelectList(_context.Khachhangs, "KhachhangId", "KhachhangId");
            return View();
        }

        // POST: Admin/AdminDonhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonhangId,KhachhangId,Masodonhang,Ngaytaodon,Trangthaidonhang,Diachigiaohang,Tongtien")] Donhang donhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhachhangId"] = new SelectList(_context.Khachhangs, "KhachhangId", "KhachhangId", donhang.KhachhangId);
            return View(donhang);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhangs.FindAsync(id);
            if (donhang == null)
            {
                return NotFound();
            }
            ViewData["KhachhangId"] = new SelectList(_context.Khachhangs, "KhachhangId", "Hovaten", donhang.KhachhangId);
            ViewData["TaikhoanId"] = new SelectList(_context.Nhanviens, "TaikhoanId", "Username", donhang.TaikhoanId);
            ViewData["TrangthaidonhangId"] = new SelectList(_context.Trangthaidonhangs, "TrangthaidonhangId", "Tentrangthaidonhang", donhang.TrangthaidonhangId);
            return View(donhang);
        }

        // POST: Admin/abcxyz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonhangId,KhachhangId,Masodonhang,Ngaytaodon,TrangthaidonhangId,Diachigiaohang,Tongtien,TaikhoanId")] Donhang donhang)
        {
            if (id != donhang.DonhangId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donhang);
                    _notyfservice.Success("Bạn đã cập nhật trạng thái đơn hàng thành công!");
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonhangExists(donhang.DonhangId))
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
            ViewData["KhachhangId"] = new SelectList(_context.Khachhangs, "KhachhangId", "KhachhangId", donhang.KhachhangId);
            ViewData["TaikhoanId"] = new SelectList(_context.Nhanviens, "TaikhoanId", "Username", donhang.TaikhoanId);
            ViewData["TrangthaidonhangId"] = new SelectList(_context.Trangthaidonhangs, "TrangthaidonhangId", "Tentrangthaidonhang", donhang.TrangthaidonhangId);
            return View(donhang);
        }
        // GET: Admin/AdminDonhangs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var donhang = await _context.Donhangs.FindAsync(id);
        //    if (donhang == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["KhachhangId"] = new SelectList(_context.Khachhangs, "KhachhangId", "Hovaten", donhang.KhachhangId);
        //    ViewData["TrangthaidonhangId"] = new SelectList(_context.Trangthaidonhangs, "TrangthaidonhangId", "Tentrangthaidonhang", donhang.TrangthaidonhangId);
        //    ViewData["TaikhoanId"] = new SelectList(_context.Nhanviens, "TaikhoanId", "Hovaten", donhang.TaikhoanId);
        //    return View(donhang);
        //}

        //// POST: Admin/AdminDonhangs/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("DonhangId,KhachhangId,Masodonhang,Ngaytaodon,TrangthaidonhangId,Diachigiaohang,Tongtien,TaikhoanId")] Donhang donhang)
        //{
        //    if (id != donhang.DonhangId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(donhang);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DonhangExists(donhang.DonhangId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["KhachhangId"] = new SelectList(_context.Khachhangs, "KhachhangId", "Hovaten", donhang.KhachhangId);
        //    ViewData["TrangthaidonhangId"] = new SelectList(_context.Trangthaidonhangs, "TrangthaidonhangId", "Tentrangthaidonhang", donhang.TrangthaidonhangId);
        //    ViewData["TaikhoanId"] = new SelectList(_context.Nhanviens, "TaikhoanId", "Hovaten", donhang.TaikhoanId);
        //    return View(donhang);
        //}

        // GET: Admin/AdminDonhangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhangs
                .Include(d => d.Khachhang)
                .FirstOrDefaultAsync(m => m.DonhangId == id);
            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }

        // POST: Admin/AdminDonhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donhang = await _context.Donhangs.FindAsync(id);
            _context.Donhangs.Remove(donhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonhangExists(int id)
        {
            return _context.Donhangs.Any(e => e.DonhangId == id);
        }
    }
}
