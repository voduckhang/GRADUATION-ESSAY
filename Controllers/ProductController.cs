using AspNetCoreHero.ToastNotification.Abstractions;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Controllers
{
    public class ProductController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfservice { get; }
        public ProductController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfservice = notyfService;
        }
        [Route("shop.html", Name = "ShopProduct")]
        public IActionResult Index(int catID, int? page, int lsp = 0, string dl = "", int gt = 0, string searchText = "")
        {
            try
            {
                if (searchText == "" && searchText == null)
                {
                    var phaghe = page == null || page <= 0 ? 1 : page.Value;
                    var danhmuclistInSearch = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                    var pagesiz = 9;
                    var timkiem = _context.Sanphams.AsNoTracking()
                        .Include(s => s.Danhmuc).Include(s => s.Hedieuhanh).
                        OrderByDescending(x => x.SanphamId);

                    PagedList<Sanpham> model = new PagedList<Sanpham>(timkiem, phaghe, pagesiz);
                    ViewBag.CurrentCategory = danhmuclistInSearch;
                    ViewBag.CurrentPage = phaghe;
                    return View(model);
                }
                if (searchText != "" && searchText != null)
                {
                    var phaghe = page == null || page <= 0 ? 1 : page.Value;
                    var danhmuclistInSearch = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                    var pagesiz = 9;
                    var timkiem = _context.Sanphams.AsNoTracking().
                        Where(p => p.Tensanpham.Contains(searchText))
                        .Include(s => s.Danhmuc).Include(s => s.Hedieuhanh).
                        OrderByDescending(x => x.SanphamId);

                    PagedList<Sanpham> model = new PagedList<Sanpham>(timkiem, phaghe, pagesiz);
                    ViewBag.CurrentCategory = danhmuclistInSearch;
                    ViewBag.CurrentPage = phaghe;
                    return View(model);
                }
                //////////////////////////////////////////////////
                if (lsp != 0 || dl != "" || gt != 0)
                {                   
                    if (lsp != 0)
                    {
                        var dsspcat_main = _context.Sanphams.AsNoTracking().Where(x => x.DanhmucId == lsp);
                        if (dl != "")
                        {
                            var dsspcat_1 = dsspcat_main.Where(x => x.Dungluong.Contains(dl));
                            if (gt != 0)
                            {
                                var dsspcat_3 = dsspcat_1.Where(x=>x.Giatien <= gt);

                                var pagenumber1 = page == null || page <= 0 ? 1 : page.Value;
                                var pagesize1 = 9;
                                var danhmuc1 = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                                PagedList<Sanpham> models1 = new PagedList<Sanpham>(dsspcat_3, pagenumber1, pagesize1);
                                ViewBag.CurrentPage = pagenumber1;
                                ViewBag.CurrentCategory = danhmuc1;
                                return View(models1);
                            }
                            else
                            {
                                var dsspcat_4 = dsspcat_1;

                                var pagenumber1 = page == null || page <= 0 ? 1 : page.Value;
                                var pagesize1 = 9;
                                var danhmuc1 = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                                PagedList<Sanpham> models1 = new PagedList<Sanpham>(dsspcat_4, pagenumber1, pagesize1);
                                ViewBag.CurrentPage = pagenumber1;
                                ViewBag.CurrentCategory = danhmuc1;
                                return View(models1);
                            }
                        }
                        else
                        {

                                var dsspcat_6 = _context.Sanphams.AsNoTracking().Where(x => x.DanhmucId == lsp);
                                if (gt != 0)
                                {
                                    var dsspcat_7 = dsspcat_6.Where(x => x.Giatien <= gt);

                                    var pagenumber1 = page == null || page <= 0 ? 1 : page.Value;
                                    var pagesize1 = 9;
                                    var danhmuc1 = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                                    PagedList<Sanpham> models1 = new PagedList<Sanpham>(dsspcat_7, pagenumber1, pagesize1);
                                    ViewBag.CurrentPage = pagenumber1;
                                    ViewBag.CurrentCategory = danhmuc1;
                                    return View(models1);
                                }
                                else
                                {
                                    var dsspcat_8 = dsspcat_6;

                                    var pagenumber1 = page == null || page <= 0 ? 1 : page.Value;
                                    var pagesize1 = 9;
                                    var danhmuc1 = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                                    PagedList<Sanpham> models1 = new PagedList<Sanpham>(dsspcat_8, pagenumber1, pagesize1);
                                    ViewBag.CurrentPage = pagenumber1;
                                    ViewBag.CurrentCategory = danhmuc1;
                                    return View(models1);
                                }
                            }
                        }
                    
                    else
                    {
                        var dsspcat_lsp = _context.Sanphams.AsNoTracking()
                         .Include(s => s.Danhmuc).Include(s => s.Hedieuhanh).
                         OrderByDescending(x => x.SanphamId);
                        if (dl != "")
                        {
                            var dsspcat_lsp_1 = dsspcat_lsp.Where(x => x.Dungluong.Contains(dl));
                            if (gt != 0)
                            {
                                var dsspcat_lsp_5 = dsspcat_lsp_1.Where(x => x.Giatien <= gt);

                                var pagenumber1 = page == null || page <= 0 ? 1 : page.Value;
                                var pagesize1 = 9;
                                var danhmuc1 = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                                PagedList<Sanpham> models1 = new PagedList<Sanpham>(dsspcat_lsp_5, pagenumber1, pagesize1);
                                ViewBag.CurrentPage = pagenumber1;
                                ViewBag.CurrentCategory = danhmuc1;
                                return View(models1);
                            }
                            else
                            {
                                var dsspcat_lsp_2 = dsspcat_lsp.Where(x => x.Dungluong.Contains(dl));

                                var pagenumber1 = page == null || page <= 0 ? 1 : page.Value;
                                var pagesize1 = 9;
                                var danhmuc1 = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                                PagedList<Sanpham> models1 = new PagedList<Sanpham>(dsspcat_lsp_2, pagenumber1, pagesize1);
                                ViewBag.CurrentPage = pagenumber1;
                                ViewBag.CurrentCategory = danhmuc1;
                                return View(models1);
                            }
                        }
                        else
                        {
                            var dsspcat_lsp_2 = _context.Sanphams.AsNoTracking()
                         .Include(s => s.Danhmuc).Include(s => s.Hedieuhanh).
                         OrderByDescending(x => x.Giatien);
                            if (gt != 0)
                            {
                                var dsspcat_lsp_3 = dsspcat_lsp_2.Where(x => x.Giatien <= gt);
                                var pagenumber1 = page == null || page <= 0 ? 1 : page.Value;
                                var pagesize1 = 9;
                                var danhmuc1 = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                                PagedList<Sanpham> models1 = new PagedList<Sanpham>(dsspcat_lsp_3, pagenumber1, pagesize1);
                                ViewBag.CurrentPage = pagenumber1;
                                ViewBag.CurrentCategory = danhmuc1;
                                return View(models1);
                            }
                            else
                            {
                                var dsspcat_lsp_4 = _context.Sanphams.AsNoTracking()
                        .Include(s => s.Danhmuc).Include(s => s.Hedieuhanh).
                        OrderByDescending(x => x.SanphamId);
                                var pagenumber1 = page == null || page <= 0 ? 1 : page.Value;
                                var pagesize1 = 9;
                                var danhmuc1 = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                                PagedList<Sanpham> models1 = new PagedList<Sanpham>(dsspcat_lsp_4, pagenumber1, pagesize1);
                                ViewBag.CurrentPage = pagenumber1;
                                ViewBag.CurrentCategory = danhmuc1;
                                return View(models1);
                            }
                        }
                    }

                    var pnumber = page == null || page <= 0 ? 1 : page.Value;
                    var lsdanhmuc = _context.Danhmucs.AsNoTracking().SingleOrDefault(x => x.DanhmucId == catID);
                    var danhmuclist = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                    var psize = 10;
                    var dsspcat = _context.Sanphams.AsNoTracking()
                           .Include(s => s.Danhmuc).Include(s => s.Hedieuhanh).
                           OrderByDescending(x => x.SanphamId);
                    PagedList<Sanpham> modelsdanhmuc = new PagedList<Sanpham>(dsspcat, pnumber, psize);
                    ViewBag.CurrentCat = lsdanhmuc;
                    ViewBag.CurrentCategory = danhmuclist;
                    ViewBag.CurrentPage = pnumber;
                    return View(modelsdanhmuc);
                }
                var pagenumber = page == null || page <= 0 ? 1 : page.Value;
                var pagesize = 9;
                var danhmuc = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                var dssanpham = _context.Sanphams.AsNoTracking().Include(s => s.Danhmuc).Include(s => s.Hedieuhanh).
                        OrderByDescending(x => x.SanphamId);
                PagedList<Sanpham> models = new PagedList<Sanpham>(dssanpham, pagenumber, pagesize);
                ViewBag.CurrentPage = pagenumber;
                ViewBag.CurrentCategory = danhmuc;
                return View(models);


            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [Route("filtercat.html/{tensp}/{min}/{max}", Name = "FilterCat")]
        public IActionResult FilterCat(int? page, int min, int max, string tensp = "")
        {
            try
            {
                if (min == 0 || max == 0)
                {
                    var pagenumbers = page == null || page <= 0 ? 1 : page.Value;
                    var pagesizes = 9;
                    var danhmucs = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                    var dssanphams = _context.Sanphams.AsNoTracking().Include(s => s.Danhmuc).Include(s => s.Hedieuhanh).
                            OrderByDescending(x => x.SanphamId);
                    PagedList<Sanpham> modelss = new PagedList<Sanpham>(dssanphams, pagenumbers, pagesizes);
                    ViewBag.CurrentPage = pagenumbers;
                    ViewBag.CurrentCategory = danhmucs;
                    return View(modelss);
                }
                if (min != 0 || max != 0)
                {
                    var phaghe = page == null || page <= 0 ? 1 : page.Value;
                    var danhmuclistInSearch = _context.Danhmucs.AsNoTracking().OrderByDescending(x => x.DanhmucId).ToList();
                    var pagesiz = 9;
                    var timkiems = _context.Sanphams.AsNoTracking().
                        Where(p => p.Tensanpham.Contains(tensp)).Where(w => w.Giatien >= min).Where(z => z.Giatien <= max)
                        .Include(s => s.Danhmuc).Include(s => s.Hedieuhanh).
                        OrderByDescending(x => x.SanphamId);

                    PagedList<Sanpham> model = new PagedList<Sanpham>(timkiems, phaghe, pagesiz);
                    ViewBag.CurrentCategory = danhmuclistInSearch;
                    ViewBag.CurrentPage = phaghe;
                    return View(model);
                }
                return RedirectToAction("Index", "Product");
            }

            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }


        [Route("/{Tensanpham}", Name = "ListProduct")]
        public IActionResult List(string ID, int page = 1)
        {
            try
            {
                var danhmuc = _context.Danhmucs.AsNoTracking().SingleOrDefault(x => x.Tendanhmuc == ID);
                var pagesize = 10;
                var dssp = _context.Sanphams.AsNoTracking().
                    Where(x => x.DanhmucId == danhmuc.DanhmucId).
                    OrderByDescending(x => x.SanphamId);
                PagedList<Sanpham> models = new PagedList<Sanpham>(dssp, page, pagesize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentDanhmuc = danhmuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [Route("/{Tensanpham}-{id}.html", Name = "ProductDetails")]
        public IActionResult Details(int id)
        {
            try
            {
                var product = _context.Sanphams.Include(x => x.Danhmuc).Include(x => x.Hedieuhanh).FirstOrDefault(x => x.SanphamId == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }


                var dssanphamlienquan = _context.Sanphams.AsNoTracking().
                    Where(x => x.SanphamId != id).Take(4).
                    OrderByDescending(x => x.SanphamId).ToList();
                ViewBag.Sanphamlienquan = dssanphamlienquan;

                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}
