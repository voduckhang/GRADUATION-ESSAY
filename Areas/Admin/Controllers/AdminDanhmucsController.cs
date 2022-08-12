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
using LUANVANTOTNGHIEP_VODUCANKHANG.Helper;
using System.IO;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDanhmucsController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfservice { get; }
        public AdminDanhmucsController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfservice = notyfService;
        }

        // GET: Admin/AdminDanhmucs

        public IActionResult Index(int? page, string searchDanhmuc="")
        {
            if (searchDanhmuc != "" && searchDanhmuc != null)
            {
                var pnumber = page == null || page <= 0 ? 1 : page.Value;
                var psize = 3;
                var lsdanhmuc = _context.Danhmucs.AsNoTracking().
                    Where(p=>p.Tendanhmuc.Contains(searchDanhmuc))
                    .OrderByDescending(x => x.DanhmucId);
                PagedList<Danhmuc> model = new PagedList<Danhmuc>(lsdanhmuc, pnumber, psize);
                ViewBag.CurrentPage = pnumber;
                return View(model);
            }
            var pagenumber = page == null || page <= 0 ? 1 : page.Value;
            var pagesize = 3;
            var dsdanhmuc = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId);
            PagedList<Danhmuc> models = new PagedList<Danhmuc>(dsdanhmuc, pagenumber, pagesize);
            ViewBag.CurrentPage = pagenumber;
            return View(models);
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Danhmucs.ToListAsync());
        //}

        // GET: Admin/AdminDanhmucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmucs
                .FirstOrDefaultAsync(m => m.DanhmucId == id);
            if (danhmuc == null)
            {
                return NotFound();
            }

            return View(danhmuc);
        }

        // GET: Admin/AdminDanhmucs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminDanhmucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DanhmucId,Tendanhmuc,Hinhanh")] Danhmuc danhmuc, Microsoft.AspNetCore.Http.IFormFile fthumb)
        {
            if (ModelState.IsValid)
            {

                danhmuc.Tendanhmuc = Utilities.ToTitleCase(danhmuc.Tendanhmuc);
                if (fthumb != null)
                {
                    string extension = Path.GetExtension(fthumb.FileName);
                    string image = Utilities.SEOUrl(danhmuc.Tendanhmuc) + extension;
                    danhmuc.Hinhanh = await Utilities.UploadFile(fthumb, @"DanhMuc", image.ToLower());
                }
                if (string.IsNullOrEmpty(danhmuc.Hinhanh)) danhmuc.Hinhanh = "~/DanhMuc/default.png";


                _context.Add(danhmuc);
                await _context.SaveChangesAsync();
                _notyfservice.Success("Tạo mới danh mục thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(danhmuc);
        }

        // GET: Admin/AdminDanhmucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmucs.FindAsync(id);
            if (danhmuc == null)
            {
                return NotFound();
            }
            return View(danhmuc);
        }

        // POST: Admin/AdminDanhmucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DanhmucId,Tendanhmuc,Hinhanh")] Danhmuc danhmuc,Microsoft.AspNetCore.Http.IFormFile fthumb)
        {
            if (id != danhmuc.DanhmucId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    danhmuc.Tendanhmuc = Utilities.ToTitleCase(danhmuc.Tendanhmuc);
                    if (fthumb != null)
                    {
                        string extension = Path.GetExtension(fthumb.FileName);
                        string image = Utilities.SEOUrl(danhmuc.Tendanhmuc) + extension;
                        danhmuc.Hinhanh = await Utilities.UploadFile(fthumb, @"images/DanhMuc", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(danhmuc.Hinhanh)) danhmuc.Hinhanh = "default.png";

                    _context.Update(danhmuc);
                    await _context.SaveChangesAsync();
                    _notyfservice.Success("Cập nhật danh mục thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhmucExists(danhmuc.DanhmucId))
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
            return View(danhmuc);
        }

        // GET: Admin/AdminDanhmucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sanpham = _context.Sanphams.Where(x => x.DanhmucId == id);
            if (sanpham.Count() > 0)
            {
                ViewBag.Massage = "Bạn không thể xóa danh mục này";
            }
            var danhmuc = await _context.Danhmucs
                .FirstOrDefaultAsync(m => m.DanhmucId == id);
            if (danhmuc == null)
            {
                return NotFound();
            }

            return View(danhmuc);
        }

        // POST: Admin/AdminDanhmucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhmuc = await _context.Danhmucs.FindAsync(id);
            var sanpham = _context.Sanphams.Where(x => x.DanhmucId == id);           
            if (sanpham.Count() > 0)
            {
                _notyfservice.Success("Bạn không thể xóa do tồn tại sản phẩm bên trong danh mục này!");
                return View(danhmuc);
            }
            _context.Danhmucs.Remove(danhmuc);
            await _context.SaveChangesAsync();
            _notyfservice.Success("Xóa danh mục thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool DanhmucExists(int id)
        {
            return _context.Danhmucs.Any(e => e.DanhmucId == id);
        }
    }
}
