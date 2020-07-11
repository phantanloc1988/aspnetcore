using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Buoi14_DatabaseFirst.Contants;
using Buoi14_DatabaseFirst.Models;
using Buoi14_DatabaseFirst.Models.MyModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Buoi14_DatabaseFirst.Controllers
{
    [Authorize]
    public class KhachHangController : Controller
    {
        private readonly eStore20Context _context;

        public KhachHangController(eStore20Context ct)
        {
            _context = ct;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous, HttpGet]
        public IActionResult Login(string ReturnUrl=null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string ReturnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var khachhang = _context.KhachHang.SingleOrDefault(p => p.MaKh == model.UserName && p.MatKhau == model.Password);

                if (khachhang == null)
                {
                    ViewBag.ThanhCong = "Đăng Nhập không Thành Công";

                    return View();               
                }
                
                //Khai báo các Claim
                var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,khachhang.HoTen),
                        new Claim(ClaimTypes.Email,khachhang.Email),
                        new Claim(ClaimTypes.Role,"KhachHang"),
                        new Claim(MyClaimTypes.MaKhachHang,khachhang.MaKh), //MyClaimTypes tự tạo, ClaimTypes có sẵn
                    };
                    
                ClaimsIdentity claimIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Profile");
            };

            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Demo()
        {
            var claims = this.User;
            var makh = claims.FindFirst(MyClaimTypes.MaKhachHang).Value;
            var role = claims.FindFirst(ClaimTypes.Role).Value;

            return Content(makh + "-" + role);
        }
    }
}