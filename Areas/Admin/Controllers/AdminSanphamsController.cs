using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using PagedList.Core;
using LUANVANTOTNGHIEP_VODUCANKHANG.Helper;
using System.IO;
using AspNetCoreHero.ToastNotification.Abstractions;
using Newtonsoft.Json;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSanphamsController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfservice { get; }
        public AdminSanphamsController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfservice = notyfService;
        }

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var postTitle = _context.Sanphams.Where(p => p.Tensanpham.Contains(term)).
                    Select(p => p.Tensanpham).ToList();
                return Ok(postTitle);
            }
            catch
            {
                return BadRequest();
            }
        }


        // GET: Admin/AdminSanphams

        public IActionResult Index(int page = 1, int CatID = 0, string searchSanpham = "")
        {
            if (searchSanpham != "" && searchSanpham != null)
            {
                var pNumber = page;
                var psize = 10;
                List<Sanpham> lsSanpham = new List<Sanpham>();

                lsSanpham = _context.Sanphams.
            AsNoTracking().
            Include(x => x.Danhmuc).Include(y => y.Hedieuhanh).
            Where(p => p.Tensanpham.Contains(searchSanpham))
            .OrderByDescending(x => x.SanphamId).ToList();

                PagedList<Sanpham> model = new PagedList<Sanpham>(lsSanpham.AsQueryable(), pNumber, psize);
                ViewBag.CurrentCateID = CatID;
                ViewBag.CurrentPage = pNumber;
                ViewData["DanhmucId"] = new SelectList(_context.Danhmucs, "DanhmucId", "Tendanhmuc", CatID);
                return View(model);
            }
            var pageNumber = page;
            var pagesize = 10;
            List<Sanpham> lsProducts = new List<Sanpham>();

            lsProducts = _context.Sanphams.
        AsNoTracking().
        Include(x => x.Danhmuc).Include(y => y.Hedieuhanh).
        OrderByDescending(x => x.SanphamId).ToList();

            PagedList<Sanpham> models = new PagedList<Sanpham>(lsProducts.AsQueryable(), pageNumber, pagesize);
            ViewBag.CurrentCateID = CatID;
            ViewBag.CurrentPage = pageNumber;
            ViewData["DanhmucId"] = new SelectList(_context.Danhmucs, "DanhmucId", "Tendanhmuc", CatID);
            return View(models);
        }


        [HttpPost]
        public IActionResult Filter(int CatID = 0)
        {
            var url = $"/Admin/AdminSanphams?CatID={CatID}";
            if (CatID == 0)
            {
                url = $"/Admin/AdminSanphams";
            }

            return Json(new { status = "success", redirectUrl = url });
        }
        // GET: Admin/AdminSanphams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .Include(s => s.Danhmuc)
                .Include(s => s.Hedieuhanh)
                .FirstOrDefaultAsync(m => m.SanphamId == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Admin/AdminSanphams/Create
        public IActionResult Create()
        {
            ViewData["DanhmucId"] = new SelectList(_context.Danhmucs, "DanhmucId", "Tendanhmuc");
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanhs, "HedieuhanhId", "Tenhedieuhanh");
            return View();
        }

        // POST: Admin/AdminSanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SanphamId,Tensanpham,Motasanpham,DanhmucId,Hinhanh,Tonkho,Dungluong,HedieuhanhId,Giatien")] Sanpham sanpham, Microsoft.AspNetCore.Http.IFormFile fthumb)
        {
            if (ModelState.IsValid)
            {

                sanpham.Tensanpham = Utilities.ToTitleCase(sanpham.Tensanpham);
                if (fthumb != null)
                {
                    string extension = Path.GetExtension(fthumb.FileName);
                    string image = Utilities.SEOUrl(sanpham.Tensanpham) + extension;
                    sanpham.Hinhanh = await Utilities.UploadFile(fthumb, @"HinhAnh", image.ToLower());
                }
                if (string.IsNullOrEmpty(sanpham.Hinhanh)) sanpham.Hinhanh = "~/default.png";


                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                _notyfservice.Success("Bạn đã thêm mới sản phẩm thành công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhmucId"] = new SelectList(_context.Danhmucs, "DanhmucId", "Tendanhmuc", sanpham.DanhmucId);
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanhs, "HedieuhanhId", "Tenhedieuhanh", sanpham.HedieuhanhId);
            return View(sanpham);
        }

        // GET: Admin/AdminSanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["DanhmucId"] = new SelectList(_context.Danhmucs, "DanhmucId", "Tendanhmuc", sanpham.DanhmucId);
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanhs, "HedieuhanhId", "Tenhedieuhanh", sanpham.HedieuhanhId);
            return View(sanpham);
        }

        // POST: Admin/AdminSanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SanphamId,Tensanpham,Motasanpham,DanhmucId,Hinhanh,Tonkho,Dungluong,HedieuhanhId,Giatien")] Sanpham sanpham, Microsoft.AspNetCore.Http.IFormFile fthumb)
        {
            if (id != sanpham.SanphamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    sanpham.Tensanpham = Utilities.ToTitleCase(sanpham.Tensanpham);
                    if (fthumb != null)
                    {
                        string extension = Path.GetExtension(fthumb.FileName);
                        string image = Utilities.SEOUrl(sanpham.Tensanpham) + extension;
                        sanpham.Hinhanh = await Utilities.UploadFile(fthumb, @"HinhAnh", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(sanpham.Hinhanh)) sanpham.Hinhanh = "~/images/default.png";


                    _context.Update(sanpham);
                    _notyfservice.Success("Bạn đã cập nhật sản phẩm thành công");
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.SanphamId))
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
            ViewData["DanhmucId"] = new SelectList(_context.Danhmucs, "DanhmucId", "Tendanhmuc", sanpham.Danhmuc.Tendanhmuc);
            ViewData["HedieuhanhId"] = new SelectList(_context.Hedieuhanhs, "HedieuhanhId", "Tenhedieuhanh", sanpham.HedieuhanhId);
            return View(sanpham);
        }

        // GET: Admin/AdminSanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var chitietdonhang = _context.Chitietdonhangs.Where(x => x.SanphamId == id);
            if (chitietdonhang.Count() > 0) 
            {
                ViewBag.Message = "Bạn Không Thể Xóa Sản Phẩm Này!";
            }
            ViewBag.Chitietdd = chitietdonhang;
            var sanpham = await _context.Sanphams
                .Include(s => s.Danhmuc)
                .Include(s => s.Hedieuhanh)
                .FirstOrDefaultAsync(m => m.SanphamId == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Admin/AdminSanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanpham = await _context.Sanphams.FindAsync(id);
            var chitietdonhang = _context.Chitietdonhangs.Where(x => x.SanphamId == id);
            if (chitietdonhang.Count() > 0)
            {
                _notyfservice.Success("Sản Phẩm Hiện Có Trong Đơn Hàng. Bạn Không Thể Xóa Nó!");
                return View(sanpham);
            }
            _context.Sanphams.Remove(sanpham);
            await _context.SaveChangesAsync();
            _notyfservice.Success("Bạn đã xóa sản phẩm thành công!");
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(int id)
        {
            return _context.Sanphams.Any(e => e.SanphamId == id);
        }
    }
}
