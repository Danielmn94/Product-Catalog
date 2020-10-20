using Product_Catalog.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product_Catalog.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        string GetDataAsJson();
    }
}
