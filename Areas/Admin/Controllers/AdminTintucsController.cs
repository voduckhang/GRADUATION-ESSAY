using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using PagedList.Core;
using System.IO;
using LUANVANTOTNGHIEP_VODUCANKHANG.Helper;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTintucsController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfservice { get; }

        public AdminTintucsController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfservice = notyfService;
        }

        // GET: Admin/AdminTintucs
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Tintucs.ToListAsync());
        //}

        public IActionResult Index(int? page, string searchTintuc="")
        {
            if (searchTintuc != "" && searchTintuc != null)
            {
                var collectionSearch = _context.Tintucs.AsNoTracking().ToList();
                foreach (var item in collectionSearch)
                {
                    if (item.Ngaytaotintuc == null)
                    {
                        item.Ngaytaotintuc = DateTime.Now;
                        _context.Update(item);
                        _context.SaveChanges();
                    }
                }

                var pnumber = page == null || page <= 0 ? 1 : page.Value;
                var psize = 10;
                var dstintucSearch = _context.Tintucs.AsNoTracking().
                    Where(p=>p.Noidung.Contains(searchTintuc))
                    .OrderByDescending(x => x.TintucId);
                PagedList<Tintuc> model = new PagedList<Tintuc>(dstintucSearch, pnumber, psize);
                ViewBag.CurrentPage = pnumber;
                return View(model);
            }
            var collection = _context.Tintucs.AsNoTracking().ToList();
            foreach(var item in collection)
            {
                if(item.Ngaytaotintuc == null){
                    item.Ngaytaotintuc = DateTime.Now;
                    _context.Update(item);
                    _context.SaveChanges();
                }
            }
            var pagenumber = page == null || page <= 0 ? 1 : page.Value;
            var pagesize = 10;
            var dstintuc = _context.Tintucs.AsNoTracking().OrderByDescending(x => x.TintucId);
            PagedList<Tintuc> models = new PagedList<Tintuc>(dstintuc, pagenumber, pagesize);
            ViewBag.CurrentPage = pagenumber;
            return View(models);
        }

        // GET: Admin/AdminTintucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs.Include(x=>x.Taikhoan)
                .FirstOrDefaultAsync(m => m.TintucId == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        // GET: Admin/AdminTintucs/Create
        public IActionResult Create()
        {
            ViewData["TaikhoanID"] = new SelectList(_context.Nhanviens, "TaikhoanId", "Hovaten");
            return View();
        }

        // POST: Admin/AdminTintucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TintucId,Tentintuc,Noidung,Hinhanhtintuc,Tieude,Ngaytaotintuc,TaikhoanId")] Tintuc tintuc,Microsoft.AspNetCore.Http.IFormFile fthumb)
        {
            if (ModelState.IsValid)
            {
                if (fthumb != null)
                {
                    string extension = Path.GetExtension(fthumb.FileName);
                    string imgName = Utilities.SEOUrl(tintuc.Tentintuc) + extension;
                    //string image = Utilities.SEOUrl(tintuc.Tentintuc) + extension;
                    tintuc.Hinhanhtintuc = await Utilities.UploadFile(fthumb, @"TinTuc", imgName.ToLower());
                }
                if (string.IsNullOrEmpty(tintuc.Hinhanhtintuc)) tintuc.Hinhanhtintuc = "default.png";


                _context.Add(tintuc);
                await _context.SaveChangesAsync();
                _notyfservice.Success("Bạn đã thêm mới tin tức thành công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaikhoanID"] = new SelectList(_context.Nhanviens, "TaikhoanId", "Hovaten", tintuc.TaikhoanId);
            return View(tintuc);
        }

        // GET: Admin/AdminTintucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs.FindAsync(id);
            if (tintuc == null)
            {
                return NotFound();
            }
            ViewData["TaikhoanID"] = new SelectList(_context.Nhanviens, "TaikhoanId", "Hovaten");
            return View(tintuc);
        }

        // POST: Admin/AdminTintucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TintucId,Tentintuc,Noidung,Hinhanhtintuc,Tieude,Ngaytaotintuc,TaikhoanId")] Tintuc tintuc, Microsoft.AspNetCore.Http.IFormFile fthumb)
        {
            if (id != tintuc.TintucId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (fthumb != null)
                    {
                        string extension = Path.GetExtension(fthumb.FileName);
                        string imgName = Utilities.SEOUrl(tintuc.Tentintuc) + extension;
                        //string image = Utilities.SEOUrl(tintuc.Tentintuc) + extension;
                        tintuc.Hinhanhtintuc = await Utilities.UploadFile(fthumb, @"TinTuc", imgName.ToLower());
                    }
                    if (string.IsNullOrEmpty(tintuc.Hinhanhtintuc)) tintuc.Hinhanhtintuc = "default.png";
                    tintuc.Ngaytaotintuc = DateTime.Now;

                    _context.Update(tintuc);

                    await _context.SaveChangesAsync();
                    _notyfservice.Success("Bạn đã cập nhật tin tức thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TintucExists(tintuc.TintucId))
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
            ViewData["TaikhoanID"] = new SelectList(_context.Nhanviens, "TaikhoanId", "Hovaten", tintuc.TaikhoanId);
            return View(tintuc);
        }

        // GET: Admin/AdminTintucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs.Include(x=>x.Taikhoan)
                .FirstOrDefaultAsync(m => m.TintucId == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        // POST: Admin/AdminTintucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tintuc = await _context.Tintucs.FindAsync(id);
            _context.Tintucs.Remove(tintuc);
            await _context.SaveChangesAsync();
            _notyfservice.Success("Bạn đã xóa tin tức thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool TintucExists(int id)
        {
            return _context.Tintucs.Any(e => e.TintucId == id);
        }
    }
}
