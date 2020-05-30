using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Buoi06.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi06.Controllers
{
    public class HangHoaController : Controller
    {
        List<HangHoa> listHangHoa = new List<HangHoa>();
        public HangHoaController()
        {
            
            listHangHoa.Add(new HangHoa
            {
                MaHH = 1,
                TenHH = "CVR",
                DonGia = 8500,
            });

            listHangHoa.Add(new HangHoa
            {
                MaHH = 2,
                TenHH = "Fortuner",
                DonGia = 43000,
            });
        }
        public IActionResult Index()
        {
            return View(listHangHoa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa hangHoa)
        {

            listHangHoa.Add(hangHoa);
            return View("Index", listHangHoa);
            //return Redirect("/HangHoa");
            /*return RedirectToAction("Index","HangHoa")*/  /*như trên*/
        }
    }
}