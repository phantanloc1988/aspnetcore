using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi06.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi06.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TruyenDuLieu()
        {
            ViewBag.NgayThanhLap = new DateTime(2003,3,20);
            ViewBag.Ten = "Nhất Nghệ";
            ViewData["Tuoi"] = 17; 
            ViewData["DienThoai"] = 012154564646;


            ViewBag.SanPham = new HangHoa
            {
                TenHH = "CRV",
                DonGia=18900,
                GiamGia=3,
            };


            return View();
        }

        

        [Route("/dien-thoai/{tendienthoai}")]
        public IActionResult ChiTiet(string tendienthoai)
        {
            return Content(tendienthoai);

        }

        [Route("/{loai}/{sanpham}")]
        public IActionResult ChiTiet(string loai, string sanpham)
        {
            return Content($"{loai} - {sanpham}");

        }
    }
}