using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Webbanraucu_Ass.Extention;
using Webbanraucu_Ass.Models;
using Webbanraucu_Ass.ModelsView;

namespace Webbanraucu_Ass.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly DBWebbanhang _context;

        public ShoppingCartsController(DBWebbanhang context)
        {
            _context = context;
        }

        public List<GioHang> GioHangs
        {
            get
            {
                var gh = HttpContext.Session.Get<List<GioHang>>("GioHangs");
                if (gh == default(List<GioHang>))
                {
                    gh = new List<GioHang>();
                }
                return gh;
            }
        }
        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddtoCart(int ProducID, int? sl)
        {
            try
            {
                List<GioHang> _giohang = GioHangs;
                GioHang iteam = GioHangs.SingleOrDefault(c => c._products.ProductID == ProducID);
                var _soluongkho = _context.Products.Where(c => c.ProductID == ProducID).Select(c => c.Amount).FirstOrDefault();
                if (iteam != null)
                {
                    var cart = HttpContext.Session.Get<List<GioHang>>("GioHangs");
                    GioHang iteam2 = cart.SingleOrDefault(c => c._products.ProductID == ProducID);
                    iteam2.soluong = iteam2.soluong + sl.Value;
                    if (iteam2.soluong > _soluongkho)
                    {
                        return Json(new { success = false });
                    }
                    HttpContext.Session.Set("GioHangs", cart);
                }
                else
                {
                    Products pr = _context.Products.SingleOrDefault(c => c.ProductID == ProducID);
                    iteam = new GioHang();
                    iteam.soluong = sl.HasValue ? sl.Value : 1;
                    iteam._products = pr;
                    if (iteam.soluong > _soluongkho)
                    {
                        return Json(new { success = false });
                    }
                    _giohang.Add(iteam);
                    HttpContext.Session.Set("GioHangs", _giohang);

                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdatetoCart(int ProducID, int? sl)
        {
            var cart = HttpContext.Session.Get<List<GioHang>>("GioHangs");
            try
            {
                if (cart != null)
                {
                    GioHang iteam = cart.SingleOrDefault(c => c._products.ProductID == ProducID);
                    var _soluongkho = _context.Products.Where(c => c.ProductID == ProducID).Select(c => c.Amount).FirstOrDefault();
                    if (iteam != null && sl.HasValue)
                    {
                        iteam.soluong = sl.Value;
                    }

                    if (iteam.soluong > _soluongkho)
                    {
                        return Json(new { success = false });
                    }
                    HttpContext.Session.Set("GioHangs", cart);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        [Route("api/cart/remote")]
        public IActionResult RemotePr(int ProducID)
        {
            try
            {
                List<GioHang> giohang = GioHangs;

                GioHang iteam = giohang.SingleOrDefault(c => c._products.ProductID == ProducID);
                if (iteam != null)
                {
                    giohang.Remove(iteam);
                }
                //Lưu lại session
                HttpContext.Session.Set("GioHangs", giohang);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [Route("cart.html", Name = "Cart")]
        public IActionResult Index()
        {
            return View(GioHangs);
        }
    }
}
