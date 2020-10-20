using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Catalog.DTO.DTO;
using Product_Catalog.MVC.Models;
using Product_Catalog.Service.Services.Interfaces;
namespace Product_Catalog.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            CreateProductViewModel vm = new CreateProductViewModel();

            vm = populateDropDown(vm);

            return View(vm);
        }

        public IActionResult CreateProduct(CreateProductViewModel vm)
        {

            if (vm.ColorID != null)
            {
                HttpContext.Session.SetString("ColorID", vm.ColorID);
            }

            var convertedVM = _mapper.Map<ProductDTO>(vm);

            if (convertedVM.StyleName == null || convertedVM.StyleName == "")
            {
                ModelState.AddModelError(string.Empty, "Style Name is required");
                vm = populateDropDown(vm);
                return View(vm);
            }

            if (convertedVM.Description == null || convertedVM.Description == "")
            {
                ModelState.AddModelError(string.Empty, "Description is required");
                vm = populateDropDown(vm);
                return View(vm);
            }


            if (convertedVM.ColorID == null || convertedVM.ColorID == "")
            {
                ModelState.AddModelError(string.Empty, "Color is required");
                vm = populateDropDown(vm);
                return View(vm);
            }

            if (convertedVM.SizeID == null || convertedVM.SizeID == "")
            {
                ModelState.AddModelError(string.Empty, "Size is required");
                vm = populateDropDown(vm);
                return View(vm);
            }

            _productService.Create(convertedVM);

            ViewBag.Msg = "Product Created";

            CreateProductViewModel vmnew = new CreateProductViewModel();
            ModelState.Clear();
            populateDropDown(vmnew);
            return View(vmnew);
        }

        private CreateProductViewModel populateDropDown(CreateProductViewModel vm)
        {

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

            return vm;
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
    }
}
