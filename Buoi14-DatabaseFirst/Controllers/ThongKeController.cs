using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Buoi14_DatabaseFirst.Models;
using Buoi14_DatabaseFirst.Models.MyModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Buoi14_DatabaseFirst.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly eStore20Context _eStore20Context;

        public ThongKeController(eStore20Context dbcontext)
        {
            _eStore20Context = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region[Thống kê]
        public IActionResult Loai()
        {
            //gom nhóm theo loại, dictionary trả về cặp (key,value), netcore 3.1 ko cho group by các OBJ


            var loais = _eStore20Context.Loai.ToDictionary(lo => lo.MaLoai);

            var data = _eStore20Context.ChiTietHd.GroupBy(p => p.MaHhNavigation.MaLoai).Select(h => new ThongKeTheoLoai
            {
                TenLoai = loais[h.Key].TenLoai,
                DoanhThu = h.Sum(cthd => cthd.SoLuong * cthd.DonGia * (1 - cthd.GiamGia)),
                SoLuong = h.Sum(cthd => cthd.SoLuong),
                GiaThapNhat = h.Min(cthd => cthd.DonGia)
            });
            return View(data);
        }

        public IActionResult KhachHang()
        {
            var dskhachhang = _eStore20Context.KhachHang.ToDictionary(kh => kh.MaKh);
            var data = _eStore20Context.ChiTietHd.GroupBy(cthd => new
            {
                cthd.MaHdNavigation.MaKh,
                cthd.MaHhNavigation.MaLoai,
            }).Select(g => new
            {
                dskhachhang[g.Key.MaKh].HoTen,
                g.Key.MaLoai,
                DoanhThu = g.Sum(cthd => cthd.DonGia * cthd.SoLuong * (1 - cthd.GiamGia))
            });
            return Json(data);
        }

        public IActionResult NamThang()
        {
            var data = _eStore20Context.ChiTietHd.GroupBy(cthd => new
            {
                cthd.MaHhNavigation.MaLoai,
                Nam = cthd.MaHdNavigation.NgayDat.Year,
                Thang = cthd.MaHdNavigation.NgayDat.Month,
            }).Select(g => new
            {
                g.Key.MaLoai,
                ThoiGian = $"{g.Key.Thang}/{g.Key.Nam}",
                DoanhThu = g.Sum(cthd => cthd.DonGia * cthd.SoLuong * (1 - cthd.GiamGia))
            });
            return Json(data);
        }

        #endregion[Thống kê]

        #region[Raw SQL Demo]
        public IActionResult RawQuery()
        {
            var para = "an";
            var data = _eStore20Context.HangHoa.FromSqlRaw($"select*from HangHoa Where TenHH Like '%{para}'");
            return Json(data);
        }

        public IActionResult RawQuery2()
        {
            var para = "an";
            var data = _eStore20Context.HangHoa.FromSqlRaw($"select*from HangHoa Where TenHH Like '%{para}'").Select(p => new TimKiemHangHoa
            {
                MaHh=p.MaHh,
                TenHh=p.TenHh,
                DonGia=p.DonGia.Value,
                GiamGia=p.GiamGia

            });
            return Json(data);
        }

        public IActionResult RawQuery3()
        {
            var mahd = 10248;
            var data = _eStore20Context.ChiTietHoaDonView.FromSqlRaw($"select * from ChiTietHoaDonView Where MaHD = {mahd}");
            return Json(data);
        }
        #endregion[Raw SQL Demo]
    }
}