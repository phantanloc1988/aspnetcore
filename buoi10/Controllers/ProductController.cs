using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using AutoMapper;
using buoi10.Models;
using buoi10.Models.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace buoi10.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }


        public IActionResult DemoMapper()
        {
            var sp = new ProductModel
            {
                productID = 1,
                Name = "samsung",
                Price = 15000,
                Quantity = 1,
            };

            var spMap = _mapper.Map<Product>(sp);
            return View(spMap);
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