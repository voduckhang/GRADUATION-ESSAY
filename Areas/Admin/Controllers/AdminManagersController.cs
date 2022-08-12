using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using LUANVANTOTNGHIEP_VODUCANKHANG.Extension;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminManagersController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfservice { get; }

        public AdminManagersController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfservice = notyfService;
        }

        // GET: Admin/AdminManagers
        public async Task<IActionResult> Index()
        {
            var qldtContext = _context.AdminManagers.Include(a => a.Phanquyen);
            return View(await qldtContext.ToListAsync());
        }

        // GET: Admin/AdminManagers/Details/5
        public async Task<IActionResult> Details(bool? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminManager = await _context.AdminManagers
                .Include(a => a.Phanquyen)
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (adminManager == null)
            {
                return NotFound();
            }

            return View(adminManager);
        }

        // GET: Admin/AdminManagers/Create
        public IActionResult Create()
        {
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyens, "PhanquyenId", "Tenquyentruycap");
            return View();
        }

        // POST: Admin/AdminManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,TenAdmin,PhanquyenId,MatkhauAdmin")] AdminManager adminManager)
        {
            if (ModelState.IsValid)
            {
               adminManager.MatkhauAdmin=adminManager.MatkhauAdmin.ToMD5();
                _context.Add(adminManager);
                _notyfservice.Success("Bạn đã thêm quản trị viên mới thành công!");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyens, "PhanquyenId", "Tenquyentruycap", adminManager.PhanquyenId);
            return View(adminManager);
        }

        // GET: Admin/AdminManagers/Edit/5
        public async Task<IActionResult> Edit(bool? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminManager = await _context.AdminManagers.FindAsync(id);
            if (adminManager == null)
            {
                return NotFound();
            }
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyens, "PhanquyenId", "Tenquyentruycap", adminManager.PhanquyenId);
            return View(adminManager);
        }

        // POST: Admin/AdminManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(bool id, [Bind("AdminId,TenAdmin,PhanquyenId,MatkhauAdmin")] AdminManager adminManager)
        {
            if (id != adminManager.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    adminManager.MatkhauAdmin = adminManager.MatkhauAdmin.ToMD5();
                    _context.Update(adminManager);
                    _notyfservice.Success("Bạn đã cập nhật thông tin quản trị viên thành công!");
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminManagerExists(adminManager.AdminId))
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
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyens, "PhanquyenId", "Tenquyentruycap", adminManager.PhanquyenId);
            return View(adminManager);
        }

        // GET: Admin/AdminManagers/Delete/5
        public async Task<IActionResult> Delete(bool? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminManager = await _context.AdminManagers
                .Include(a => a.Phanquyen)
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (adminManager == null)
            {
                return NotFound();
            }

            return View(adminManager);
        }

        // POST: Admin/AdminManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(bool id)
        {
            var adminManager = await _context.AdminManagers.FindAsync(id);
            _context.AdminManagers.Remove(adminManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminManagerExists(bool id)
        {
            return _context.AdminManagers.Any(e => e.AdminId == id);
        }
        public IActionResult Logout_AdminManager()
        {

            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("AdminId");
            return RedirectToAction("Index", "AdminDonHangs");

        }
    }
}
