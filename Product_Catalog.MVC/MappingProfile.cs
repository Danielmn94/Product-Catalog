using AutoMapper;
using Product_Catalog.Data.Domain.Models;
using Product_Catalog.DTO.DTO;
using Product_Catalog.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Catalog.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductViewModel, ProductDTO>();
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.ColorID, opt => opt.MapFrom(src => int.Parse(src.ColorID)));
        }
    }
}
