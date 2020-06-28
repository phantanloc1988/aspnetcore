using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi14_DatabaseFirst.Helpers;
using Buoi14_DatabaseFirst.Models;
using Buoi14_DatabaseFirst.Models.MyModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Buoi14_DatabaseFirst.Controllers
{
    public class HangHoasController : Controller
    {
        private readonly eStore20Context _eStore20Context;

        public HangHoasController(eStore20Context ctx)
        {
            _eStore20Context = ctx;
        }


        public IActionResult Index(int? PageCount, string SapXep, int page = 1 )
        {
            var pageCount = PageCount.HasValue ? PageCount.Value : 20;

            if (string.IsNullOrEmpty(SapXep))
            {
                SapXep = "TenHh";
            }

            var pageCountSelected = MyTools.Pages.SingleOrDefault(p => p.Value == pageCount);

            ViewBag.Pages = new SelectList(MyTools.Pages, "Value", "Text",pageCountSelected);

            var result = _eStore20Context.HangHoa.AsQueryable();
            switch (SapXep.ToLower())
            {
                case "tenHh": result = result.OrderBy(p => p.TenHh); break;
                case "dongia": result = result.OrderBy(p => p.DonGia).ThenBy(p => p.TenHh); break;
            }

            var danhsach = result.Select(p => new TimKiemHangHoa
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                DonGia = p.DonGia.Value,
                Hinh = MyTools.CheckImageExist(p.Hinh, "HangHoa"),
                GiamGia = p.GiamGia,
                NgaySx = p.NgaySx
            }).Skip((page - 1) * pageCount).Take(pageCount).ToList();

            return View(danhsach);
        }

        [HttpGet]
        public IActionResult TimKiem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TimKiem(string keyword,int? giatu, int? giaden)
        {
            var dsHangHoa = _eStore20Context.HangHoa.Where(hh => hh.TenHh.Contains(keyword));
            if (giatu.HasValue)
            {
                dsHangHoa = dsHangHoa.Where(hh => hh.DonGia >= giatu);
            }
            if (giaden.HasValue)
            {
                dsHangHoa = dsHangHoa.Where(p => p.DonGia <= giaden);
            }

            var result = dsHangHoa.Select(p => new TimKiemHangHoa
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                DonGia=p.DonGia.Value,
                Hinh= MyTools.CheckImageExist(p.Hinh,"HangHoa"),
                GiamGia=p.GiamGia,
                NgaySx=p.NgaySx
            }).ToList();
            return View(result);
        }
    }
}