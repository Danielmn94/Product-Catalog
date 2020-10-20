using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Product_Catalog.MVC.Models;

namespace Product_Catalog.MVC.Controllers
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
            CreateProductViewModel vm = new CreateProductViewModel();

            vm.ListOfColors = new List<SelectListItem> 
            { 
                new SelectListItem() { Text = "Red", Value = "1" },
                new SelectListItem() { Text = "Green", Value = "2"},
                new SelectListItem() { Text = "Blue", Value = "3"}
            };
            vm.ListOfColors.Insert(0, new SelectListItem() { Text = "Select color", Value = string.Empty });

            vm.ListOfSizes = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Small", Value = "S" },
                new SelectListItem() { Text = "Medium", Value = "M"},
                new SelectListItem() { Text = "Large", Value = "L"},
                new SelectListItem() { Text = "Xtra Large", Value = "XL"}
            };
            vm.ListOfSizes.Insert(0, new SelectListItem() { Text = "Select size", Value = string.Empty });

            return View(vm);
        }

        public IActionResult CreateProduct(CreateProductViewModel vm)
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
    }
}
