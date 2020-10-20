using Product_Catalog.Data.Domain.Models;
using Product_Catalog.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product_Catalog.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Product_CatalogContext _context;
        public ProductRepository(Product_CatalogContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
    }
}
