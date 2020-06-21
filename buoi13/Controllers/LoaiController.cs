using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using buoi13.Helpers;
using buoi13.Models;
using Microsoft.AspNetCore.Mvc;

namespace buoi13.Controllers
{
    public class LoaiController : Controller
    {
        LoaiDataAccessLayer loaiDAL;
        public LoaiController()
        {
            loaiDAL = new LoaiDataAccessLayer();
        }
        public IActionResult Index()
        {
            return View(loaiDAL.GetLoais());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loai loai)
        {
            int maLoaiThem = loaiDAL.AddLoai(loai);

            //return Redirect($"/Loai/Edit/{maLoaiThem}");
            return RedirectToAction("Loai", "Edit", new { id = maLoaiThem });
        }

        public IActionResult Edit(int id)
        {
            var loai = loaiDAL.GetLoai(id);

            return View(loai);
        }

        [HttpPost]
        public IActionResult Edit(Loai loai)
        {
            loaiDAL.UpdateLoai(loai);

            return View("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                loaiDAL.DeleteLoai(id);
                ViewBag.ThongBao = "Xóa Thành công";
                TempData["ThongBao"]= "Xóa Thành công";
            }
            catch (Exception ex)
            {
                ViewBag.ThongBao = "Xóa không Thành công";
                TempData["ThongBao"] = "Xóa không Thành công";
            }
            

            return View("Index");
        }


    }
}