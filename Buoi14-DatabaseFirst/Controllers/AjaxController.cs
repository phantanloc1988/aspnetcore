using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi14_DatabaseFirst.Models;
using Buoi14_DatabaseFirst.Models.MyModels;
using Microsoft.AspNetCore.Mvc;

namespace Buoi14_DatabaseFirst.Controllers
{
    public class AjaxController : Controller
    {
        private readonly eStore20Context _context;

        public AjaxController(eStore20Context ctx)
        {
            _context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ServerTime()
        {
            var text = DateTime.Now.ToString("dd/mm/yyyy HH:mm:ss tt");
            return Content(text);
        }

        // tim2 kiem hang2 hoa theo tên
        public IActionResult HangHoa()
        {
            return View();
        }

        
        public IActionResult Search(string Keyword)
        {
            var data = _context.HangHoa.Where(hh => hh.TenHh.ToLower().Contains(Keyword)).Select(hh => new TimKiemHangHoa
            {
                MaHh=hh.MaHh,
                TenHh=hh.TenHh,
                DonGia=hh.DonGia.Value,
                GiamGia=hh.GiamGia,
                Hinh=hh.Hinh,
                NgaySx=hh.NgaySx
            });

            return PartialView(data);
        }
    }
}