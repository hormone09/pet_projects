using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TAVI_Pavlodar.Model;

namespace TAVI_Pavlodar.Data
{
    public class AplicationDbContext : IdentityDbContext<User, Role, Guid>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> Types { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaesElement> PurchaesElements { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Loading> Loadings { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<ProductOnLoading> ProductsForLoading { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Basket>().HasMany(x => x.items);
            builder.Entity<Purchase>().HasMany(x => x.purchaesElements);
            builder.Entity<User>().HasMany(x => x.FavoriteProducts);
            builder.Entity<Loading>().HasMany(x => x.Products);

            base.OnModelCreating(builder);
        }

    }
}
