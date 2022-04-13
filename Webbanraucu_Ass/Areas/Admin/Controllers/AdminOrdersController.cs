using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using Webbanraucu_Ass.Models;

namespace Webbanraucu_Ass.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly DBWebbanhang _context;

        public AdminOrdersController(DBWebbanhang context)
        {
            _context = context;
        }

        // GET: Admin/AdminOrders
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsOrder = _context.Orders.Include(o => o.Customers).Include(o => o.TransacStatus)
                .AsNoTracking().OrderByDescending(c => c.OrderDat);
            PagedList<Orders> models = new PagedList<Orders>(lsOrder, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }
        // GET: Admin/AdminOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Customers)
                .Include(o => o.TransacStatus)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (orders == null)
            {
                return NotFound();
            }

            var chitietdonhang = _context.OrderDetails.AsNoTracking()
                .Include(c=>c.Products)
                .Where(c => c.OrderID == orders.OrderID)
                .OrderByDescending(c => c.OrderDetailsID).ToList();
            ViewBag.ChiTiet = chitietdonhang;
            return View(orders);
        }

        // GET: Admin/AdminOrders/Edit/5
        public async Task<IActionResult> ChangeStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.AsNoTracking().Include(c=>c.Customers).FirstOrDefaultAsync(c=>c.OrderID == id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["Trangthai"] = new SelectList(_context.TransacStatus, "TransacStatuID", "Status", orders.TransacStatuID);
            return PartialView("_ChangeStatus", orders);
        }

        // POST: Admin/AdminOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus(int id, [Bind("OrderID,CustomerID,OrderDat,TransacStatuID,TotoMoney")] Orders orders)
        {
            if (id != orders.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var donhang = await _context.Orders.AsNoTracking().Include(c => c.Customers).FirstOrDefaultAsync(c => c.OrderID == id);
                    if (donhang != null)
                    {
                        donhang.TransacStatuID = orders.TransacStatuID;
                    }
                    _context.Update(donhang);
                    await _context.SaveChangesAsync();
                    if (donhang.TransacStatuID == 5)
                    {
                        var chitietdonhang = _context.OrderDetails
                            .Include(c => c.Products)
                            .Where(c => c.OrderID == orders.OrderID)
                            .ToList();

                        var _producid = _context.OrderDetails
                            .Include(c => c.Products)
                            .Where(c => c.OrderID == orders.OrderID)
                            .Select(c => c.ProductsID).ToList();

                        

                        for (int i = 0; i < chitietdonhang.Count; i++)
                        {
                           
                            var _quatily = chitietdonhang[i].Quantity;

                            var _tongqualyti = _context.Products
                                .Where(c => c.ProductID == _producid[i])
                                .Select(c => c.Amount).FirstOrDefault();

                            var _products = _context.Products
                                .FirstOrDefault(c => c.ProductID == _producid[i]);

                            _products.Amount = _tongqualyti - _quatily;
                            _context.Update(_products);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrderID))
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
            ViewData["Trangthai"] = new SelectList(_context.TransacStatus, "TransacStatuID", "Status", orders.TransacStatuID);
            return PartialView("_ChangeStatus",orders);
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
