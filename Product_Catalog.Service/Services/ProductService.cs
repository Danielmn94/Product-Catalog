using Product_Catalog.Data.Domain.Models;
using Product_Catalog.Data.Repositories;
using Product_Catalog.Data.Repositories.Interfaces;
using Product_Catalog.DTO.DTO;
using Product_Catalog.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Text;

namespace Product_Catalog.Service.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(ProductDTO productDTO)
        {
            //Get Text from ColorID and SizeID
            var colorName = (Color)Enum.Parse(typeof(Color), productDTO.ColorID);

            var sizeName = GroupTypesStr[(int)Size.S];
            //Create ItemNo
            var itemNo = productDTO.StyleName + productDTO.ColorID + productDTO.SizeID;

            //Save to Database

            Product product = new Product
            {
                ColorName = colorName.ToString(),
                ColorID = Int32.Parse(productDTO.ColorID),
                SizeName = sizeName.ToString(),
                SizeID = productDTO.SizeID,
                Description = productDTO.Description,
                ItemNo = itemNo,
                StyleName = productDTO.StyleName,
                Sustainable = productDTO.Sustainable
            };

            _productRepository.CreateProduct(product);


        }

        private enum Color
        {
            Red = 01,
            Green = 02,
            Blue = 03
        }

        private enum Size
        {
            S = 0,
            M = 1,
            L = 2,
            XL = 3
        }

        string[] GroupTypesStr = {
            "Small",
            "Medium",
            "Large",
            "Xtra Large"
        };
    }
}
