using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webbanraucu_Ass.Models;

namespace Webbanraucu_Ass.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSearchController : Controller
    {

        private readonly DBWebbanhang _context;
        public AdminSearchController(DBWebbanhang context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult FindProduct(string keywork)
        {
            List<Products> _lsProducts = new List<Products>();
            List<Products> _lsProducts2 = new List<Products>();
            _lsProducts2 = _context.Products
                .AsNoTracking().Include(c => c.Categories).OrderByDescending(c => c.ProductID).ToList();
            if (string.IsNullOrEmpty(keywork) || keywork.Length < 1)
            {
                return PartialView("_Listproducts_searchpratial", _lsProducts2);
            }

            _lsProducts = _context.Products
                .AsNoTracking().Include(c => c.Categories)
                .Where(c => c.ProductName.Contains(keywork))
                .OrderByDescending(c => c.ProductID).ToList();

            return PartialView("_Listproducts_searchpratial", _lsProducts);
        }

        [HttpPost]
        public IActionResult FindOrder(string keywork)
        {
            List<Orders> _lsOrders = new List<Orders>();
            List<Orders> _lsOrders2 = new List<Orders>();
            _lsOrders = _context.Orders
                .AsNoTracking()
                .Include(c => c.Customers)
                .Include(c => c.TransacStatus)
                .OrderByDescending(c => c.OrderID).ToList();
            if (string.IsNullOrEmpty(keywork) || keywork.Length < 1)
            {
                return PartialView("_Listorders_searchpratial", _lsOrders);
            }

            _lsOrders2 = _context.Orders
                .AsNoTracking()
                .Include(c => c.Customers)
                .Include(c => c.TransacStatus)
                .Where(c=>c.OrderID == Convert.ToInt32(keywork))
                .OrderByDescending(c => c.OrderID)
                .ToList();

            return PartialView("_Listorders_searchpratial", _lsOrders2);
        }
    }
}
