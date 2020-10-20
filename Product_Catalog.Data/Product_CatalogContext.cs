using Microsoft.EntityFrameworkCore;
using Product_Catalog.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product_Catalog.Data
{
    public class Product_CatalogContext : DbContext
    {
        public Product_CatalogContext(DbContextOptions<Product_CatalogContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
