using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Buoi07.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Buoi07.Controllers
{
    public class HangHoaController : Controller
    {
        static List<HangHoa> ListHangHoa = new List<HangHoa>();
        
        public IActionResult Index()
        {

            return View(ListHangHoa);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa SanPham, IFormFile Hinh)
        {
            if (Hinh!=null)
            {
                var Filename = $"{DateTime.Now.Ticks}_{Hinh.FileName}";
                var DuongDan = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "HangHoa", Filename);

                using (FileStream filestream = new FileStream(DuongDan, FileMode.Create))
                {
                    Hinh.CopyTo(filestream);
                };

                SanPham.Hinh = Filename;
                ListHangHoa.Add(SanPham);
                return View("Index", ListHangHoa);

            }

            return View();
        }
    }
}