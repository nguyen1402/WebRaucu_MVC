using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Webbanraucu_Ass.Models;
using Webbanraucu_Ass.ModelsView;

namespace Webbanraucu_Ass.Controllers
{
    public class DonHangController : Controller
    {
        private readonly DBWebbanhang _context;

        public DonHangController(DBWebbanhang context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var taikhoanid = HttpContext.Session.GetString("CustomerID");
                if (string.IsNullOrEmpty(taikhoanid))
                {
                    return RedirectToAction("DangNhap", "Accounts");
                }

                var khachhang = _context.Customers.AsNoTracking()
                    .SingleOrDefault(c => c.CustomerID == Convert.ToInt32(taikhoanid));
                if (khachhang == null)
                {
                    return NotFound();
                }

                var donhang = await _context.Orders.Include(c => c.TransacStatus)
                    .FirstOrDefaultAsync(c => c.OrderID == id && Convert.ToInt32(taikhoanid) == c.CustomerID);
                if (donhang == null)
                {
                    return NotFound();
                }

                var chitietdonhang = _context.OrderDetails
                    .Include(c => c.Products)
                    .AsNoTracking()
                    .Where(c => c.OrderID == id)
                    .OrderByDescending(c=>c.OrderDetailsID)
                    .ToList();

                XemDonHang don_hang = new XemDonHang();
                don_hang.DonHang = donhang;
                don_hang.ChiTietDonHang = chitietdonhang;

                return PartialView("Details", don_hang);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
