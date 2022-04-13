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
    public class AdminAccountsController : Controller
    {
        private readonly DBWebbanhang _context;

        public AdminAccountsController(DBWebbanhang context)
        {
            _context = context;
        }

        // GET: Admin/AdminAccounts
        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var _lsAccounts = _context.Accounts.AsNoTracking().Include(a => a.Roles)
                .OrderByDescending(c=>c.AccountID);
            PagedList<Accounts> models = new PagedList<Accounts>(_lsAccounts, pageNumber, pageSize);
            ViewBag.Curren = pageNumber;
            ViewData["Quyen"] = new SelectList(_context.Roles, "RoleID", "RoleName");
            return View(models);
        }

        // GET: Admin/AdminAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounts = await _context.Accounts
                .Include(a => a.Roles)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (accounts == null)
            {
                return NotFound();
            }

            return View(accounts);
        }

        // GET: Admin/AdminAccounts/Create
        public IActionResult Create()
        {
            ViewData["Quyen"] = new SelectList(_context.Roles, "RoleID", "RoleName");
            return View();
        }

        // POST: Admin/AdminAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountID,Email,Phone,Password,Salt,Active,Fullname,RoleID,Lastlogin,Creatdate")] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Quyen"] = new SelectList(_context.Roles, "RoleID", "RoleName", accounts.RoleID);
            return View(accounts);
        }

        // GET: Admin/AdminAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounts = await _context.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return NotFound();
            }
            ViewData["Quyen"] = new SelectList(_context.Roles, "RoleID", "RoleName", accounts.RoleID);
            return View(accounts);
        }

        // POST: Admin/AdminAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountID,Email,Phone,Password,Salt,Active,Fullname,RoleID,Lastlogin,Creatdate")] Accounts accounts)
        {
            if (id != accounts.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsExists(accounts.AccountID))
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
            ViewData["Quyen"] = new SelectList(_context.Roles, "RoleID", "RoleName", accounts.RoleID);
            return View(accounts);
        }

        // GET: Admin/AdminAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounts = await _context.Accounts
                .Include(a => a.Roles)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (accounts == null)
            {
                return NotFound();
            }

            return View(accounts);
        }

        // POST: Admin/AdminAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accounts = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(accounts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountsExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountID == id);
        }
    }
}
