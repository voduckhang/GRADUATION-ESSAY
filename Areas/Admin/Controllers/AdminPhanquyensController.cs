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
    public class AdminPhanquyensController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfservice { get; }
        public AdminPhanquyensController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfservice = notyfService;
        }

        // GET: Admin/AdminPhanquyens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Phanquyens.ToListAsync());
        }

        // GET: Admin/AdminPhanquyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanquyen = await _context.Phanquyens
                .FirstOrDefaultAsync(m => m.PhanquyenId == id);
            if (phanquyen == null)
            {
                return NotFound();
            }

            return View(phanquyen);
        }

        // GET: Admin/AdminPhanquyens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPhanquyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhanquyenId,Tenquyentruycap")] Phanquyen phanquyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanquyen);
                await _context.SaveChangesAsync();
                _notyfservice.Success("Bạn đã tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(phanquyen);
        }

        // GET: Admin/AdminPhanquyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanquyen = await _context.Phanquyens.FindAsync(id);
            if (phanquyen == null)
            {
                return NotFound();
            }
            return View(phanquyen);
        }

        // POST: Admin/AdminPhanquyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhanquyenId,Tenquyentruycap")] Phanquyen phanquyen)
        {
            if (id != phanquyen.PhanquyenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanquyen);
                    await _context.SaveChangesAsync();
                    _notyfservice.Success("Bạn đã chỉnh sửa phân quyền thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanquyenExists(phanquyen.PhanquyenId))

                    {
                        _notyfservice.Success("Có một lỗi đã xảy ra!");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(phanquyen);
        }

        // GET: Admin/AdminPhanquyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanquyen = await _context.Phanquyens
                .FirstOrDefaultAsync(m => m.PhanquyenId == id);
            if (phanquyen == null)
            {
                return NotFound();
            }

            return View(phanquyen);
        }

        // POST: Admin/AdminPhanquyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanquyen = await _context.Phanquyens.FindAsync(id);
            _context.Phanquyens.Remove(phanquyen);
            await _context.SaveChangesAsync();
            _notyfservice.Success("Bạn đã xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool PhanquyenExists(int id)
        {
            return _context.Phanquyens.Any(e => e.PhanquyenId == id);
        }
    }
}
