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
    public class BlogController : Controller
    {
        private readonly qldtContext _context;
        public BlogController(qldtContext context)
        {
            _context = context;
        }

        [Route("blogs.html",Name ="Blog")]
        public IActionResult Index(int? page, int id, string searchBlog="")
        {
            if(searchBlog != "" && searchBlog != null)
            {
                var pnumber = page == null || page <= 0 ? 1 : page.Value;
                var psize = 4;
                var lstintuc = _context.Tintucs.AsNoTracking().Include(m => m.Taikhoan).
                    Where(b=>b.Noidung.Contains(searchBlog))
                    .OrderByDescending(x => x.TintucId);
                PagedList<Tintuc> model = new PagedList<Tintuc>(lstintuc, pnumber, psize);
                ViewBag.CurrentPage = pnumber;


                var dsblogsplienquan = _context.Tintucs.AsNoTracking().Include(m => m.Taikhoan).
                        Where(x => x.TintucId != id).
                        OrderByDescending(x => x.TintucId).Take(3).ToList();
                ViewBag.Tintuclienquan = dsblogsplienquan;


                return View(model);
            }
            var pagenumber = page == null || page <= 0 ? 1 : page.Value;
            var pagesize = 4;
            var dstintuc = _context.Tintucs.AsNoTracking().Include(m => m.Taikhoan).OrderByDescending(x => x.TintucId);
            PagedList<Tintuc> models = new PagedList<Tintuc>(dstintuc, pagenumber, pagesize);
            ViewBag.CurrentPage = pagenumber;

            
            var dssanphamlienquan = _context.Tintucs.AsNoTracking().Include(m => m.Taikhoan).
                    Where(x => x.TintucId != id).
                    OrderByDescending(x => x.TintucId).Take(3).ToList();
            ViewBag.Tintuclienquan = dssanphamlienquan;


            return View(models);
        }
        [Route("/tintuc/{Tieude}-{id}.html",Name ="TinDetails")]
        public IActionResult Details(int id)
        {
            var tintuc = _context.Tintucs.Include(m=>m.Taikhoan).AsNoTracking().SingleOrDefault(x => x.TintucId == id);
            if (tintuc == null)
            {
                return RedirectToAction("Index");
            }
            var baivietlienquan = _context.Tintucs.AsNoTracking().Include(m => m.Taikhoan).AsNoTracking().
                Where(x => x.TintucId != id).Take(3).OrderByDescending(x=>x.TintucId).ToList();
            ViewBag.baivietlienquan = baivietlienquan;
            return View(tintuc);
        }
    }
}
