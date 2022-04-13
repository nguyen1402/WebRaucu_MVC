using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Webbanraucu_Ass.Extention;
using Webbanraucu_Ass.Models;
using Webbanraucu_Ass.ModelsView;

namespace Webbanraucu_Ass.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly DBWebbanhang _context;
        public INotyfService _NotyfService { get; }

        public CheckoutController(DBWebbanhang context, INotyfService notyfService)
        {
            _context = context;
            _NotyfService = notyfService;
        }

        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index()
        {
            // lấy giỏ hàng ra để xử lí
            var cart = HttpContext.Session.Get<List<GioHang>>("GioHangs");
            var taikhoanid = HttpContext.Session.GetString("CustomerID");
            MuaHangVM muahang = new MuaHangVM();
            if (taikhoanid != null)
            {
                var khachhang = _context.Customers.AsNoTracking()
                    .SingleOrDefault(c => c.CustomerID == Convert.ToInt32(taikhoanid));
                muahang.Customerid = khachhang.CustomerID;
                muahang.Fullname = khachhang.FullName;
                muahang.Phone = khachhang.Phone;
                muahang.Email = khachhang.Email;
                muahang.Address = khachhang.Address;
            }

            ViewBag.GioHang = cart;
            return View(muahang);
        }
        [HttpPost]
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(MuaHangVM muaHangVm)
        {
            // lấy giỏ hàng ra để xử lí
            var cart = HttpContext.Session.Get<List<GioHang>>("GioHangs");
            var taikhoanid = HttpContext.Session.GetString("CustomerID");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanid != null)
            {
                var khachhang = _context.Customers.AsNoTracking()
                    .SingleOrDefault(c => c.CustomerID == Convert.ToInt32(taikhoanid));
                model.Customerid = khachhang.CustomerID;
                model.Fullname = khachhang.FullName;
                model.Phone = khachhang.Phone;
                model.Email = khachhang.Email;
                model.Address = khachhang.Address;

                khachhang.FullName = muaHangVm.Fullname;
                khachhang.Phone = muaHangVm.Phone;
                khachhang.Address = muaHangVm.Address;
                _context.Update(khachhang);
                _context.SaveChangesAsync();
            }

            try
            {
                //Khởi tạo đơn hàng
                    Orders orders = new Orders();
                    orders.CustomerID = model.Customerid;
                    orders.OrderDat = DateTime.Now;
                    orders.TransacStatuID = 1; // đơn mới
                    orders.TotoMoney = cart.Sum(c => c.Tongtien);
                    _context.Add(orders);
                    _context.SaveChanges();


                    //Tạo danh sách đơn hàng
                    foreach (var iteam in cart)
                    {
                        OrderDetails orderDetails = new OrderDetails();
                        orderDetails.OrderID = orders.OrderID;
                        orderDetails.ProductsID = iteam._products.ProductID;
                        orderDetails.Quantity = iteam.soluong;
                        orderDetails.TotalMoney = iteam.Tongtien;
                        _context.Add(orderDetails);
                    }

                    _context.SaveChanges();
                    HttpContext.Session.Remove("GioHangs");
                    _NotyfService.Success("Đơn hàng đã được đặt thành công !");
                    return RedirectToAction("Success");
            }
            catch
            {
                return View(model);
            }
        }

        [Route("dat-hang-thanh-cong.html", Name = "Success")]
        public IActionResult Success()
        {
            try
            {
                var taikhoanid = HttpContext.Session.GetString("CustomerID");
                if (string.IsNullOrEmpty(taikhoanid))
                {
                    return RedirectToAction("DangNhap", "Accounts");
                }

                var khachhang = _context.Customers.AsNoTracking()
                    .SingleOrDefault(c => c.CustomerID == Convert.ToInt32(taikhoanid));
                var donhang = _context.Orders.Where(c => c.CustomerID == Convert.ToInt32(taikhoanid)).OrderByDescending(c => c.OrderID).FirstOrDefault();
                MuaHangSuccessVM muaHangSuccess = new MuaHangSuccessVM();
                muaHangSuccess.DonHangID = donhang.OrderID;
                muaHangSuccess.FullName = khachhang.FullName;
                muaHangSuccess.Phone = khachhang.Phone;
                muaHangSuccess.Address = khachhang.Address;
                muaHangSuccess.Ngaydat = DateTime.Now;
                return View(muaHangSuccess);
            }
            catch
            {
                return View();
            }
        }

    }
}
