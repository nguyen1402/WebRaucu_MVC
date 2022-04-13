using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Webbanraucu_Ass.Extention;
using Webbanraucu_Ass.Heppper;
using Webbanraucu_Ass.Models;
using Webbanraucu_Ass.ModelsView;
using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Webbanraucu_Ass.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly DBWebbanhang _context;
        public INotyfService _NotyfService { get; }

        public AccountsController(DBWebbanhang context, INotyfService notyfService)
        {
            _context = context;
            _NotyfService = notyfService;
        }
        [Route("tai-khoan-cua-toi.html", Name = "Dashboard")]
        public IActionResult Dashboard()
        {

            var taikhoanid = HttpContext.Session.GetString("CustomerID");
            if (taikhoanid != null)
            {
                var khachhang = _context.Customers.AsNoTracking()
                    .SingleOrDefault(c => c.CustomerID == Convert.ToInt32(taikhoanid));
                if (khachhang != null)
                {
                    var lsdonhang = _context.Orders.AsNoTracking().Include(c => c.TransacStatus).Include(c => c.OrderDetails).Where(c => c.CustomerID == khachhang.CustomerID)
                        .OrderByDescending(c => c.OrderDat).ToList();
                    ViewBag.Danhsachdonhang = lsdonhang;
                    return View(khachhang);
                }
                return RedirectToAction("DangNhap");
            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "Dang-Ky")]
        public IActionResult DangkyTaiKhoan()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("dang-ky.html", Name = "Dang-Ky")]
        public async Task<IActionResult> DangkyTaiKhoan(RegiterViewModels taikhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var email = _context.Customers.FirstOrDefault(c => c.Email.Equals(taikhoan.Email));
                    var phone = _context.Customers.FirstOrDefault(c => c.Phone.Equals(taikhoan.Phone));
                    if (email != null)
                    {
                        _NotyfService.Error("Email đã tồn tại, Vui lòng nhập email khác");
                        return RedirectToAction("DangkyTaiKhoan", "Accounts");
                    }
                    if (phone != null)
                    {
                        _NotyfService.Error("Số điện thoại đã tồn tại, Vui lòng nhập số điện thoại khác");
                        return RedirectToAction("DangkyTaiKhoan", "Accounts");
                    }
                    string salt = Utilities.GetRandomKey();
                    Customers khachhang = new Customers
                    {
                        FullName = taikhoan.FullName,
                        Phone = taikhoan.Phone.Trim().ToLower(),
                        Email = taikhoan.Email.Trim().ToLower(),
                        Password = (taikhoan.Password + salt.Trim()).ToMD5(),
                        Actice = true,
                        Salt = salt,
                        CreatDate = DateTime.Now
                    };
                    try
                    {
                        _context.Add(khachhang);
                        await _context.SaveChangesAsync();
                        //Luu ss 
                        HttpContext.Session.SetString("CustomerID", khachhang.CustomerID.ToString());
                      
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, khachhang.FullName),
                            new Claim("CustomerID", khachhang.CustomerID.ToString())
                        };
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "DangNhap");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);

                        _NotyfService.Success("Đăng nhập thành công !");
                        return RedirectToAction("Dashboard", "Accounts");

                    }
                    catch
                    {
                        return RedirectToAction("DangkyTaiKhoan", "Accounts");
                    }
                }
                return View(taikhoan);
            }
            catch
            {
                return View(taikhoan);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "Dang-Nhap")]
        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("dang-nhap.html", Name = "Dang-Nhap")]
        public async Task<IActionResult> DangNhap(LoginViewsModel customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _khachhang = _context.Customers.AsNoTracking().SingleOrDefault(c => c.Email.Trim() == customer.Email);
                    if (_khachhang == null) return RedirectToAction("DangkyTaiKhoan");
                    string pass = (customer.Password + _khachhang.Salt.Trim()).ToMD5();
                    if (_khachhang.Password != pass)
                    {
                        _NotyfService.Error("Thông tin đăng nhập bị sai");
                        return View(customer);
                    }
                    //Luu ss 
                    HttpContext.Session.SetString("CustomerID", _khachhang.CustomerID.ToString());
                   
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, _khachhang.FullName),
                        new Claim("CustomerID", _khachhang.CustomerID.ToString())
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "DangNhap");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    _NotyfService.Success("Đăng nhập thành công!");
                    return RedirectToAction("Dashboard", "Accounts");
                }
            }
            catch
            {
                return RedirectToAction("DangkyTaiKhoan", "Accounts");
            }
            return View(customer);
        }
        [HttpGet]
        [Route("dang-xuat.html", Name = "Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("CustomerID");
            HttpContext.Session.Remove("GioHangs");
            _NotyfService.Success("Tài khoản đã đăng xuất !");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult ChangedPassword(ChangedPasswordVM _changed)
        {
            try
            {
                var idcustorm = HttpContext.Session.GetString("CustomerID");
                if (idcustorm == null)
                {
                    return RedirectToAction("DangNhap", "Accounts");
                }

                if (ModelState.IsValid)
                {
                    var taikhoan = _context.Customers.Find(Convert.ToInt32(idcustorm));
                    if (taikhoan == null)
                    {
                        return RedirectToAction("DangNhap", "Accounts");
                    }
                    var pass = (_changed.PasswordNow.Trim() + taikhoan.Salt.Trim()).ToMD5();
                    if (pass == taikhoan.Password)
                    {
                        var passnew = (_changed.PasswordNew.Trim() + taikhoan.Salt.Trim()).ToMD5();
                        taikhoan.Password = passnew;
                        _context.Update(taikhoan);
                        _context.SaveChangesAsync();
                        _NotyfService.Success("Đổi mật khẩu thành công !");
                        return RedirectToAction("Dashboard", "Accounts");
                    }
                }
            }
            catch
            {
                _NotyfService.Success("Đổi mật khẩu thất bại !");
                return RedirectToAction("Dashboard", "Accounts");
            }
            _NotyfService.Error("Đổi mật khẩu thất bại !");
            return RedirectToAction("Dashboard", "Accounts");
        }

    }
}
