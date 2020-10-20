using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Catalog.MVC.Models
{
    public class CreateProductViewModel
    {
        public string StyleName { get; set; }
        public string Description { get; set; }
        public string ColorID { get; set; }
        public string SizeID { get; set; }
        public bool Sustainable { get; set; }

        public List<SelectListItem> ListOfColors { get; set; }
        public List<SelectListItem> ListOfSizes { get; set; }
    }

}
