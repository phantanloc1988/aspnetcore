using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Buoi06.Controllers
{
    public class CalculatorController : Controller
    {



        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost] /*cùng method với form, nếu ko để auto theo Form*/
        public IActionResult Calculate(double ToanHang1, double ToanHang2, string PhepToan)
        {
            double ketqua = 0;

            switch (PhepToan)
            {
                case "+":
                    ketqua = ToanHang1 + ToanHang2;
                    break;
                case "-":
                    ketqua = ToanHang1 - ToanHang2;
                    break;
                case "*":
                    ketqua = ToanHang1 * ToanHang2;
                    break;
                case "/":
                    ketqua = ToanHang1 / ToanHang2;
                    break;
                case "^":
                    ketqua = Math.Pow(ToanHang1, ToanHang2);
                    break;

            }


            // hiển thị qua View Index
            ViewBag.A = ToanHang1;
            ViewBag.B = ToanHang2;
            ViewBag.PhepToan = PhepToan;
            ViewBag.KQ = ketqua;



            return View("Index"); 
            //return Content($"{ToanHang1}{PhepToan}{ToanHang2}={ketqua}");
        }
    }
}