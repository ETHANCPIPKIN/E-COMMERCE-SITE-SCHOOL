using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMMERCE_SITE.Models;

namespace ECOMMERCE_SITE.Models.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) {}
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ECOMMERCE_SITE.Models.RegisterViewModel> RegisterViewModel { get; set; }
    }
}
