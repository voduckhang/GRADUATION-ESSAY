using AspNetCoreHero.ToastNotification.Abstractions;
using LUANVANTOTNGHIEP_VODUCANKHANG.Extension;
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;
using LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow.CommonModels;

namespace LUANVANTOTNGHIEP_VODUCANKHANG.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly qldtContext _context;
        public INotyfService _notyfService { get; }
        public ShoppingCartController(qldtContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }


        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddToCart(int productID, int? amount)
        {
            List<CartItem> giohang = GioHang;
            try
            {
                CartItem item = GioHang.SingleOrDefault(p => p.product.SanphamId == productID);
                if (item != null)
                {
                    if (amount.HasValue)
                    {
                        item.amount = amount.Value;
                    }
                    else
                    {
                        item.amount++;
                    }
                }
                else
                {
                    Sanpham hh = _context.Sanphams.SingleOrDefault(p => p.SanphamId == productID);
                    item = new CartItem
                    {
                        amount = amount.HasValue ? amount.Value : 1,
                        product = hh
                    };
                    giohang.Add(item);
                }
                HttpContext.Session.Set<List<CartItem>>("GioHang", giohang);
                _notyfService.Success("Them San Pham Thanh Cong");
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
          
        }

        [HttpPost]
        [Route("api/cart/remove")]
        //[HttpGet("api/cart/remove/{id}")]
        public IActionResult Remove(int productID)
        {
            try
            {
                List<CartItem> giohang = GioHang;
                CartItem item = giohang.SingleOrDefault(p => p.product.SanphamId == productID);
                if (item != null)
                {
                    giohang.Remove(item);
                }
                HttpContext.Session.Set<List<CartItem>>("GioHang", giohang);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
           
        }

        [Route("cart.html",Name ="Cart")]
        public IActionResult Index()
        { 
                return View(GioHang);
               
        }

        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdateCart(int productID, int? amount)
        {
            var soluongsanpham = _context.Sanphams.AsNoTracking().Where(x => x.SanphamId==productID);
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            try
            {
                if (cart != null)
                {
                    CartItem item = cart.SingleOrDefault(p => p.product.SanphamId == productID);
                    if(item!=null && amount.HasValue)
                    {
                        if (amount.Value >item.product.Tonkho)
                        {
                            //_notyfService.Success("Xin lỗi chúng tôi chỉ còn" + soluongsanpham.Count() + "sản phẩm. Bạn có thể chọn sản phẩm khác không?");
                            //return RedirectToAction("Index", "ShoppingCart");
                            return Json(new { success = false });
                        }
                        item.amount = amount.Value;
                    }
                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
    }
}
