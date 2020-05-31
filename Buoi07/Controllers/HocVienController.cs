using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Buoi07.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Buoi07.Controllers
{
    public class HocVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ThongTin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThongTin(HocVien hv, string Ghi)
        {
            if (Ghi== "Ghi Text")
            {
                StreamWriter sw = new StreamWriter("HocVien.txt");
                sw.WriteLine(hv.MaSo);
                sw.WriteLine(hv.HoTen);
                sw.WriteLine(hv.SoDT);
                sw.WriteLine(hv.DiemTb);
                sw.WriteLine(hv.GioiTinh);
                sw.Close();
            }

            else if (Ghi == "Ghi JSON")
            {
                string ChuoiJson = JsonConvert.SerializeObject(hv); //Đổi từ OBJ sang chuỗi JSON, nguoc lại DeserializeObject


                System.IO.File.WriteAllText("HocVien.JSON", ChuoiJson);
            }
            return View();
        }

        public IActionResult DocJSON()
        {
            var content = System.IO.File.ReadAllText("HocVien.JSON");
            
            //chuyển từ file JSON sang OBJ
            var hocvien = JsonConvert.DeserializeObject<HocVien>(content);

            return View("ThongTin",hocvien);
        }

        public IActionResult DocText()
        {
            var content = System.IO.File.ReadAllLines("HocVien.txt");


            var hocvien = new HocVien
            {
                MaSo = int.Parse(content[0]),
                HoTen = content[1],
                SoDT = content[2],
                DiemTb = double.Parse(content[3]),
                GioiTinh= content[4]=="true"? true: false,
            };

            return View("ThongTin", hocvien);
        }

        public IActionResult DemoJson()
        {
            var hocvien = new HocVien
            {
                MaSo = 1,
                HoTen = "loc",
                GioiTinh = true,
                SoDT = "012145646",
                DiemTb = 8.1,
            };

            //return Json(hocvien);
            return Json(new { status = true, TrungTam = "Nhất Nghệ", NgayTHanhLap = new DateTime(2013, 3, 10) });
        }
    }
}