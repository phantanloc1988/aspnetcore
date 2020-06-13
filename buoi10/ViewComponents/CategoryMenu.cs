using buoi10.Models.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace buoi10.ViewComponents
{
    public class CategoryMenu : ViewComponent
    {
        private readonly IProductService _services;

        public CategoryMenu(IProductService services)
        {
            _services = services;
        }

        public IViewComponentResult Invoke()
        {
            return View("Default",_services.GetAll());
        }
    }
}
