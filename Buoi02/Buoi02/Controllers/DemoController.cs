using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi02.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LayMotSP()
        {
            var SH = new HangHoa()
            {
                MaHangHoa = 3,
                TenHangHoa = "SH",
                DonGia = 140000000,
            };

            return View(SH);

        }

        public IActionResult DanhSachSP()
        {
            var DanhSach = new List<HangHoa>();
            var tam = new HangHoa();

            var rd = new Random();
            var SoPhanTu = rd.Next(3, 11);


            for (int i = 0; i < SoPhanTu ; i++)
            {
                tam.MaHangHoa = 1 + 100;
                tam.DonGia = rd.NextDouble()*1000000;
                tam.TenHangHoa = $"Samsung{rd.Next()}";
                tam.GiamGia = rd.NextDouble();

                DanhSach.Add(tam);
            }

            return View(DanhSach);
        }

        public IActionResult DemoHinhHoc()
        {
           

            return View();
        }
    }
}