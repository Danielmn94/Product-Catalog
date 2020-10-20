using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Product_Catalog.DTO.DTO;
using Product_Catalog.MVC.Models;
using Product_Catalog.Service.Services;
using Product_Catalog.Service.Services.Interfaces;

namespace Product_Catalog.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            CreateProductViewModel vm = new CreateProductViewModel();

            vm.ListOfColors = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Red", Value = "01" },
                new SelectListItem() { Text = "Green", Value = "02"},
                new SelectListItem() { Text = "Blue", Value = "03"}
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
            ProductDTO dto = new ProductDTO 
            { 
                Description = vm.Description, 
                ColorID = vm.ColorID, 
                SizeID = vm.SizeID, 
                StyleName = vm.StyleName, 
                Sustainable = vm.Sustainable 
            };

            _productService.Create(dto);

            return View();
        }

        public ActionResult GetDataAsJson()
        {
            var json = _productService.GetDataAsJson();

            var data = json;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
            var output = new FileContentResult(bytes, "application/octet-stream");
            output.FileDownloadName = DateTime.Now.ToShortDateString() + ".json";

            return output;
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
