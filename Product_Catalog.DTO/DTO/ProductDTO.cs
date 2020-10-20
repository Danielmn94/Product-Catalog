using System;
using System.Collections.Generic;
using System.Text;

namespace Product_Catalog.DTO.DTO
{
    public class ProductDTO
    {
        public string StyleName { get; set; }
        public string Description { get; set; }
        public string ColorID { get; set; }
        public string SizeID { get; set; }
        public bool Sustainable { get; set; }
    }
}
