using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using Webbanraucu_Ass.Models;

namespace Webbanraucu_Ass.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DBWebbanhang _context;

        public ProductsController(DBWebbanhang context)
        {
            _context = context;
        }
        [Route("shop.html", Name = "Shop")]
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 9;
            var _lsproduct = _context.Products.AsNoTracking()
                .Where(c=>c.Amount > 0)
                .OrderByDescending(c => c.ProductID);
            PagedList<Products> models = new PagedList<Products>(_lsproduct, pageNumber, pageSize);
            ViewBag.Curren = pageNumber;
            return View(models);
        }
        //[Route("{CatName}", Name = "LsProduct")]
        //public IActionResult List(string CatName, int page = 1)
        //{
        //    var pageSize = 10;
        //    var danhmuc = _context.Categories.AsNoTracking().SingleOrDefault(c => c.CatName == CatName);
        //    var _lsproduct = _context.Products.AsNoTracking()
        //        .Where(c => c.CatID == danhmuc.CatID)
        //        .OrderByDescending(c => c.ProductID);
        //    PagedList<Products> models = new PagedList<Products>(_lsproduct, page, pageSize);
        //    ViewBag.Curren = page;
        //    ViewBag.CurrenCatid = danhmuc;
        //    return View(models);
        //}
        [Route("/{ProductName}-{id}.html", Name = "PRDetails")]
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(c => c.Categories).FirstOrDefault(c => c.ProductID == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            var lsproduct = _context.Products.AsNoTracking().Include(c => c.Categories)
                .Where(c => c.CatID == product.CatID && c.CatID != id && c.Amount > 0)
                .ToList();
            ViewBag.LSsp = lsproduct;
            return View(product);
        }
        
    }
}
