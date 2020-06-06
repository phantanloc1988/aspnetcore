using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buoi08_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace buoi08_1.Controllers
{
    public class NhanVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ThemNhanVien()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemNhanVien(NhanVien nv)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("lỗi", "Server chưa hợp lệ");
            }
            return View();
        }


        public IActionResult KiemTraMaNhanVien(int MaNhanVien)
        { 
            int[] dsMA = new int[] { 77, 12, 45, 66, 99 };
            if (dsMA.Contains(MaNhanVien))
            {
                return Json("mã này đã có");
            }

            return Json(true);
        }
    }
}