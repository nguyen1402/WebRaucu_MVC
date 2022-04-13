using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using Webbanraucu_Ass.Models;

namespace Webbanraucu_Ass.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBWebbanhang _context;

        public HomeController(ILogger<HomeController> logger, DBWebbanhang context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 8;
            var _lsproduct = _context.Products.AsNoTracking()
                .Where(c=>c.Amount > 0)
                .OrderByDescending(c => c.ProductID);
            PagedList<Products> models = new PagedList<Products>(_lsproduct, pageNumber, pageSize);
            ViewBag.Curren = pageNumber;
            return View(models);
        }
        public IActionResult LienHe()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
