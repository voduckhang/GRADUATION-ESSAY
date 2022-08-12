using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestThuocTinhNhanviensController : Controller
    {
        private readonly qldtContext _context;

        public TestThuocTinhNhanviensController(qldtContext context)
        {
            _context = context;
        }

        // GET: Admin/TestThuocTinhNhanviens
        public async Task<IActionResult> Index()
        {
            var qldtContext = _context.Nhanviens.Include(n => n.Phanquyen).Include(n => n.Trangthai);
            return View(await qldtContext.ToListAsync());
        }

        // GET: Admin/TestThuocTinhNhanviens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(n => n.Phanquyen)
                .Include(n => n.Trangthai)
                .FirstOrDefaultAsync(m => m.TaikhoanId == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Admin/TestThuocTinhNhanviens/Create
        public IActionResult Create()
        {
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyens, "PhanquyenId", "PhanquyenId");
            ViewData["TrangthaiId"] = new SelectList(_context.Trangthais, "TrangthaiId", "TrangthaiId");
            return View();
        }

        // POST: Admin/TestThuocTinhNhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaikhoanId,Username,Hovaten,Matkhau,PhanquyenId,Ngaytao,TrangthaiId,Cmnd,Ngaysinh,Diachi,Gioitinh")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyens, "PhanquyenId", "PhanquyenId", nhanvien.PhanquyenId);
            ViewData["TrangthaiId"] = new SelectList(_context.Trangthais, "TrangthaiId", "TrangthaiId", nhanvien.TrangthaiId);
            return View(nhanvien);
        }

        // GET: Admin/TestThuocTinhNhanviens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyens, "PhanquyenId", "PhanquyenId", nhanvien.PhanquyenId);
            ViewData["TrangthaiId"] = new SelectList(_context.Trangthais, "TrangthaiId", "TrangthaiId", nhanvien.TrangthaiId);
            return View(nhanvien);
        }

        // POST: Admin/TestThuocTinhNhanviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaikhoanId,Username,Hovaten,Matkhau,PhanquyenId,Ngaytao,TrangthaiId,Cmnd,Ngaysinh,Diachi,Gioitinh")] Nhanvien nhanvien)
        {
            if (id != nhanvien.TaikhoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.TaikhoanId))
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
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyens, "PhanquyenId", "PhanquyenId", nhanvien.PhanquyenId);
            ViewData["TrangthaiId"] = new SelectList(_context.Trangthais, "TrangthaiId", "TrangthaiId", nhanvien.TrangthaiId);
            return View(nhanvien);
        }

        // GET: Admin/TestThuocTinhNhanviens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(n => n.Phanquyen)
                .Include(n => n.Trangthai)
                .FirstOrDefaultAsync(m => m.TaikhoanId == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Admin/TestThuocTinhNhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            _context.Nhanviens.Remove(nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(int id)
        {
            return _context.Nhanviens.Any(e => e.TaikhoanId == id);
        }
    }
}
