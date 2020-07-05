using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi14_DatabaseFirst.Models;
using Buoi14_DatabaseFirst.Models.MyModels;
using Microsoft.AspNetCore.Mvc;

namespace Buoi14_DatabaseFirst.Controllers
{
    public class TimKiemController : Controller
    {
        private readonly eStore20Context _context;

        public TimKiemController(eStore20Context ct)
        {
            _context = ct;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JsonSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JsonSearch(JSonSearchModel model)
        {
            var data = _context.HangHoa.AsQueryable();

            if (!string.IsNullOrEmpty(model.tenHh))
            {
                data = data.Where(hh => hh.TenHh.Contains(model.tenHh));

            }
            if (model.GiaTu>0)
            {
                data = data.Where(hh => hh.DonGia >= model.GiaTu);
            }

            var result = data.Select(hh => new
            {
               hh.TenHh, hh.DonGia, hh.MaLoaiNavigation.TenLoai, hh.Hinh
            }).ToList();

            return Json(result);
        }      
    }
}