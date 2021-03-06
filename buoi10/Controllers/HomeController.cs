﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using buoi10.Models;
using buoi10.Models.Services.Interfaces;

namespace buoi10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ISingletonService _services5;


        public HomeController(ILogger<HomeController> logger, ISingletonService s5)
        {
            _services5 = s5;
            _logger = logger;

        }

        public IActionResult Index()
        {
            ViewBag.Service5= _services5.GetID();
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
    }
}
