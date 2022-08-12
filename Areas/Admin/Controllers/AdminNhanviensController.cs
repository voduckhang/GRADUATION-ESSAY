using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using LUANVANTOTNGHIEP_VODUCANKHANG.Extension;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminNhanviensController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfservice { get; }
        public AdminNhanviensController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfservice = notyfService;
        }

        // GET: Admin/AdminNhanviens
        public async Task<IActionResult> Index()
        {
            //ViewData["Tenquyentruycap"] = new SelectList(_context.Phanquyens, "Tenquyentruycap", "Tenquyentruycap");

            //var qldtContext = _context.Nhanviens.Include(n => n.Phanquyen);

       
            var collection = _context.Nhanviens.AsNoTracking().Include(x=>x.Phanquyen).Include(m=>m.Trangthai).ToList();
            foreach (var item in collection)
            {
                if (item.Ngaytao == null)
                {
                    item.Ngaytao = DateTime.Now;
                    _context.Update(item);
                    _context.SaveChanges();
                }
            }
            return View(collection);
        }

        // GET: Admin/AdminNhanviens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(n => n.Phanquyen).Include(m => m.Trangthai)
                .FirstOrDefaultAsync(m => m.TaikhoanId == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Admin/AdminNhanviens/Create
        public IActionResult Create()
        {
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyens, "PhanquyenId", "Tenquyentruycap");
            return View();
        }

        // POST: Admin/AdminNhanviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaikhoanId,Username,Hovaten,Matkhau,PhanquyenId,Ngaytao,TrangthaiId,Cmnd,Ngaysinh,Diachi,Gioitinh")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                if (nhanvien.Gioitinh.Contains("Nam"))
                {
                    nhanvien.Gioitinh = "Nam";
                }
                else if (nhanvien.Gioitinh.Contains("Nữ"))
                {
                    nhanvien.Gioitinh = "Nữ";
                }
                else if (nhanvien.Gioitinh.Contains("Other"))
                {
                    nhanvien.Gioitinh = "Giới Tính Khác";
                }
                nhanvien.TrangthaiId = true;
                nhanvien.PhanquyenId = 2;   
                nhanvien.Matkhau = nhanvien.Matkhau.ToMD5();
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                _notyfservice.Success("Bạn đã thêm mới tài khoản quản trị thành công!");
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhanquyenId"] = new SelectList(_context.Phanquyens, "PhanquyenId", "PhanquyenId", nhanvien.PhanquyenId);
            return View(nhanvien);
        }

        // GET: Admin/AdminNhanviens/Edit/5
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
            ViewData["TrangthaiId"] = new SelectList(_context.Trangthais, "TrangthaiId", "Tentrangthai", nhanvien.TrangthaiId);
            return View(nhanvien);
        }

        // POST: Admin/TestThuNhanviens/Edit/5
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
                    _notyfservice.Success("Bạn đã cập nhật tài khoản nhân viên thành công!");
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
        // GET: Admin/AdminNhanviens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanviens
                .Include(n => n.Phanquyen)
                .FirstOrDefaultAsync(m => m.TaikhoanId == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Admin/AdminNhanviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            _context.Nhanviens.Remove(nhanvien);
            await _context.SaveChangesAsync();
            _notyfservice.Success("Bạn đã xóa tài khoản quản trị thành công!");
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(int id)
        {
            return _context.Nhanviens.Any(e => e.TaikhoanId == id);
        }
    }
}
