using buoi10.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;


namespace buoi10.Controllers
{
    public class DemoController : Controller
    {
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
