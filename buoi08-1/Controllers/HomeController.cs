using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using buoi08_1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Reflection.Metadata.Ecma335;

namespace buoi08_1.Controllers
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


        public string DemoAsync()
        {
            Stopwatch sw = new Stopwatch();
            DemoAsync demo = new Models.DemoAsync();
            sw.Start();
            demo.Test01();
            demo.Test02();
            demo.Test03();
            sw.Stop();
            return $"Chạy hết {sw.ElapsedMilliseconds} ms.";
        }

        public async Task<string> Async()
        {
            Stopwatch sw = new Stopwatch();
            DemoAsync demo = new DemoAsync();
            sw.Start();
            var a = demo.Test01Async();
            var b = demo.Test02Async();
            var c = demo.Test03Async();
            await a; await b; await c;
            sw.Stop();
            return $"Chạy hết {sw.ElapsedMilliseconds} ms.";
        }

        public IActionResult DemoRazor()
        {
            return View();
        }
    }
}
