using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TimkiemController : Controller
    {
        private readonly qldtContext _context;
        public TimkiemController (qldtContext context)
        {
            _context = context;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Timkiemsanpham(string keyword)
        {
            List<Sanpham> ds = new List<Sanpham>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListProductSearchPartial", null);
            }
            ds = _context.Sanphams.AsNoTracking().Include(a => a.DanhmucId).Include(b => b.HedieuhanhId)
                .Where(x => x.Tensanpham.Contains(keyword))
                .OrderByDescending(x => x.Tensanpham)
                .Take(10).ToList();
            if (ds == null)
            {
                return PartialView("ListProductSearchPartial", null);
            }
            else
            {
                return PartialView("ListProductSearchPartial", ds);
            }    
        }
    }
}
