using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebApplication.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
