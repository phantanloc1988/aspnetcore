using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi14_DatabaseFirst.Helpers;
using Buoi14_DatabaseFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buoi14_DatabaseFirst.Controllers
{
    public class DemoSessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriteSession()
        {
            HttpContext.Session.SetInt32("NamThanhLap",2003);
            HttpContext.Session.SetString("Ten", "Nhất Nghệ");

            var loai = new Loai
            {
                MaLoai = 1, TenLoai = "bia"
            };
            HttpContext.Session.SetSession<Loai>("Loai", loai);
            return Redirect("/DemoSession/Index");
        }
    }
}