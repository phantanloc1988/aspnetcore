using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using buoi09.Models;
using Microsoft.AspNetCore.Http;

namespace buoi09.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public string TaoMaBaoMat()
        {
            //Sinh ra mã ngẫu nhiên
            Random rd = new Random();
            var maNgauNhien = rd.Next(1000, 10000).ToString();
            //luu mã ngẫu nhiên vô Session
            HttpContext.Session.SetString("maBaoMat", maNgauNhien.ToString());
            return maNgauNhien;
        }

        public IActionResult Validate()
        {
            ViewBag.MaNgauNhien = TaoMaBaoMat();

            return View();
        }
        public string KiemTraMaBaoMat(string MaBaoMat)
        {
            var mabaomatServer = HttpContext.Session.GetString("maBaoMat");
            
            return mabaomatServer.Equals(MaBaoMat) ? "true" : "false";
        }

        public string RefreshMaBaoMat()
        {
            return TaoMaBaoMat();
        }
    }
}
