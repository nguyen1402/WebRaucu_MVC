using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using Webbanraucu_Ass.Heppper;
using Webbanraucu_Ass.Models;

namespace Webbanraucu_Ass.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductsController : Controller
    {
        private readonly DBWebbanhang _context;
        public INotyfService _NotyfService { get; }

        public AdminProductsController(DBWebbanhang context, INotyfService NotyfService)
        {
            _context = context;
            _NotyfService = NotyfService;
        }

        // GET: Admin/AdminProducts
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsCustorm = _context.Products.AsNoTracking().Include(x => x.Categories).OrderByDescending(x => x.ProductID);
            PagedList<Products> models = new PagedList<Products>(lsCustorm, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;

            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatID", "CatName");
            return View(models);
        }

        // GET: Admin/AdminProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Admin/AdminProducts/Create
        public IActionResult Create()
        {
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatID", "CatName");
            return View();
        }

        // POST: Admin/AdminProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,SortDesc,Description,CatID,Price,Amount,Hinhanh,DateCreat,DateModifier")] Products products, Microsoft.AspNetCore.Http.IFormFile Hinhanh)
        {
            if (ModelState.IsValid)
            {
                products.ProductName = Utilities.ToTitleCase(products.ProductName);
                if (Hinhanh != null)
                {
                    string extention = Path.GetExtension(Hinhanh.FileName);
                    string image = Utilities.SEOUrl(products.ProductName) + extention;
                    products.Hinhanh = await Utilities.UploadFile(Hinhanh, @"products", image.ToLower());
                }

                if (string.IsNullOrEmpty(products.Hinhanh)) products.Hinhanh = "default.jpg";
                products.DateCreat = DateTime.Now;
                products.DateModifier = DateTime.Now;
                _context.Add(products);
                await _context.SaveChangesAsync();
                _NotyfService.Success("Thêm mới thành công !");
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatID", "CatName", products.CatID);
            return View(products);
        }

        // GET: Admin/AdminProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatID", "CatName", products.CatID);
            return View(products);
        }

        // POST: Admin/AdminProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,SortDesc,Description,CatID,Price,Amount,Hinhanh,DateCreat,DateModifier")] Products products, Microsoft.AspNetCore.Http.IFormFile Hinhanh)
        {
            if (id != products.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                try
                {
                    products.ProductName = Utilities.ToTitleCase(products.ProductName);
                    if (Hinhanh != null)
                    {
                        string extention = Path.GetExtension(Hinhanh.FileName);
                        string image = Utilities.SEOUrl(products.ProductName) + extention;
                        products.Hinhanh = await Utilities.UploadFile(Hinhanh, @"products", image.ToLower());
                    }

                    if (string.IsNullOrEmpty(products.Hinhanh)) products.Hinhanh = "default.jpg";
                    products.DateModifier = DateTime.Now;
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                    _NotyfService.Success("Sửa thành công !");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatID", "CatName", products.CatID);
            return View(products);
        }

        // GET: Admin/AdminProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Admin/AdminProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
