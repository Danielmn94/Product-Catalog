using AutoMapper;
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
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public string GetDataAsJson()
        {
            return _productRepository.GetDataAsJson();
        }

        public void Create(ProductDTO productDTO)
        {
            var sizeName = "";

            //Get Text from ColorID and SizeID
            var colorName = (Color)Enum.Parse(typeof(Color), productDTO.ColorID);

            switch (productDTO.SizeID)
            {
                case "S":
                    sizeName = GroupTypesStr[(int)Size.S];
                    break;
                case "M":
                    sizeName = GroupTypesStr[(int)Size.M];
                    break;
                case "L":
                    sizeName = GroupTypesStr[(int)Size.L];
                    break;
                case "XL":
                    sizeName = GroupTypesStr[(int)Size.XL];
                    break;
                default:
                    break;
            }

            //Create ItemNo
            var itemNo = productDTO.StyleName + productDTO.ColorID + productDTO.SizeID;

            //Save to database
            var convertedDTO = _mapper.Map<Product>(productDTO);
            convertedDTO.ColorName = colorName.ToString();
            convertedDTO.SizeName = sizeName;
            convertedDTO.ItemNo = itemNo;

            _productRepository.CreateProduct(convertedDTO);
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
