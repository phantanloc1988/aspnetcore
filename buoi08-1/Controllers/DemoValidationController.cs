using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buoi08_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace buoi08_1.Controllers
{
    public class DemoValidationController : Controller
    {
        public IActionResult ThemNhanVien()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemNhanVien(EmployeeInfo employee)
        {
            return View();
        }

        public IActionResult AddEmployee()
        {
            return View();
        }
    }
}