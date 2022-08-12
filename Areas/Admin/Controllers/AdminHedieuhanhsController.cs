using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHedieuhanhsController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfservice { get; }
        public AdminHedieuhanhsController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfservice = notyfService;
        }

        // GET: Admin/AdminHedieuhanhs
        public async Task<IActionResult> Index(string searchHedieuhanh="")
        {
            if (searchHedieuhanh != "" && searchHedieuhanh != null)
            {
                var dsHedieuhanhSearch = _context.Hedieuhanhs.AsNoTracking().
                    Where(p => p.Tenhedieuhanh.Contains(searchHedieuhanh))
                    .OrderByDescending(x => x.HedieuhanhId).ToList();
                return View(dsHedieuhanhSearch);
            }
            return View(await _context.Hedieuhanhs.ToListAsync());
        }

        // GET: Admin/AdminHedieuhanhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hedieuhanh = await _context.Hedieuhanhs
                .FirstOrDefaultAsync(m => m.HedieuhanhId == id);
            if (hedieuhanh == null)
            {
                return NotFound();
            }

            return View(hedieuhanh);
        }

        // GET: Admin/AdminHedieuhanhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminHedieuhanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HedieuhanhId,Tenhedieuhanh")] Hedieuhanh hedieuhanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hedieuhanh);
                await _context.SaveChangesAsync();
                _notyfservice.Success("Bạn đã thêm hệ điều hành thành công!");
                return RedirectToAction(nameof(Index));
            }
            return View(hedieuhanh);
        }

        // GET: Admin/AdminHedieuhanhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hedieuhanh = await _context.Hedieuhanhs.FindAsync(id);
            if (hedieuhanh == null)
            {
                return NotFound();
            }
            return View(hedieuhanh);
        }

        // POST: Admin/AdminHedieuhanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HedieuhanhId,Tenhedieuhanh")] Hedieuhanh hedieuhanh)
        {
            if (id != hedieuhanh.HedieuhanhId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hedieuhanh);
                    await _context.SaveChangesAsync();
                    _notyfservice.Success("Bạn đã cập nhật hệ điều hành thành công!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HedieuhanhExists(hedieuhanh.HedieuhanhId))
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
            return View(hedieuhanh);
        }

        // GET: Admin/AdminHedieuhanhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sanpham = _context.Sanphams.Where(x => x.HedieuhanhId == id);
            if (sanpham.Count() > 0)
            {
                ViewBag.Massage = "Bạn không thể xóa hệ điều hành này";
            }
            var hedieuhanh = await _context.Hedieuhanhs
                .FirstOrDefaultAsync(m => m.HedieuhanhId == id);
            if (hedieuhanh == null)
            {
                return NotFound();
            }

            return View(hedieuhanh);
        }

        // POST: Admin/AdminHedieuhanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hedieuhanh = await _context.Hedieuhanhs.FindAsync(id);
            var sanpham = _context.Sanphams.Where(x => x.HedieuhanhId == id);
            if (sanpham.Count() > 0)
            {
                _notyfservice.Success("Bạn không thể xóa do tồn tại sản phẩm bên trong hệ điều hành này!");
                return View(hedieuhanh);
            }
            _context.Hedieuhanhs.Remove(hedieuhanh);
            await _context.SaveChangesAsync();
            _notyfservice.Success("Bạn đã xóa hệ điều hành thành công!");
            return RedirectToAction(nameof(Index));
        }

        private bool HedieuhanhExists(int id)
        {
            return _context.Hedieuhanhs.Any(e => e.HedieuhanhId == id);
        }
    }
}
