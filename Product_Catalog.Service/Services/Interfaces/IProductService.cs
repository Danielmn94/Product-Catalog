using Product_Catalog.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product_Catalog.Service.Services.Interfaces
{
    public interface IProductService
    {
        void Create(ProductDTO productDTO);
    }
}
