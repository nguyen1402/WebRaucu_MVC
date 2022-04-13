using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webbanraucu_Ass.Models;

namespace Webbanraucu_Ass.Controllers
{
    public class SeachProdutsController : Controller
    {
        private readonly DBWebbanhang _context;

        public SeachProdutsController(DBWebbanhang context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Timkiem(string tksp)
        {
            List<Products> _lsProductsList1 = new List<Products>();
            List<Products> _lsProductsList2 = new List<Products>();
            _lsProductsList1 = _context.Products.AsNoTracking().Include(c => c.Categories).ToList();
            if (string.IsNullOrEmpty(tksp) || tksp.Length < 1)
            {
                return PartialView("_partialTK_view", _lsProductsList1);
            }

            _lsProductsList2 = _context.Products.AsNoTracking().Include(c => c.Categories)
                .Where(c => c.ProductName.Contains(tksp))
                .ToList();
            return PartialView("_partialTK_view", _lsProductsList2);
        }
    }
}
