﻿using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products => Set<Product>();
    }
}