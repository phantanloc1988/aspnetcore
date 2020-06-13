using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using buoi10.Models;
using buoi10.Models.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace buoi10.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var dsHH = _productService.GetAll();
            return View(dsHH);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product sanpham)
        {
            _productService.AddProduct(sanpham);
            return RedirectToAction("Index");
        }
    }
}