using buoi10.Models;
using buoi10.Models.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;


namespace buoi10.Controllers
{
    public class DemoController : Controller
    {
        private ITransientService _services1;
        private ITransientService _services2;

        private IScopedService _services3;
        private IScopedService _services4;

        private ISingletonService _services5;

        public DemoController(ITransientService s1,
                          ITransientService s2, IScopedService s3, IScopedService s4, ISingletonService s5)
        {
            _services1 = s1;
            _services2 = s2;

            _services3 = s3;
            _services4 = s4;

            _services5 = s5;
        }


        //demo transient, scoped
        public IActionResult DemoTransient()
        {
            ViewBag.Service1 = _services1.GetID();
            ViewBag.Service2 = _services2.GetID();
            ViewBag.Service3 = _services3.GetID();
            ViewBag.Service4 = _services4.GetID();
            ViewBag.Service5 = _services5.GetID();
            return View();
        }


        public IActionResult DemoMyLayout()
        {
            return View();
        }

        public IActionResult LayDanhMuc()
        {

            var danhMucDT = new DanhMuc
            {
                TenDanhMuc = "Điện Thoại",
                SanPham = new string[] { "iphone", "SamSung", "nokia" }
            };

            return PartialView("_DanhMuc", danhMucDT);
        }

        public IActionResult DemoNestLayout()
        {
            return View();  
        }
    }
}
