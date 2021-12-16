using System.Reflection;
using Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {

        #region Constractor

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        #endregion

        #region Properties
        public DbSet<ProductType> productTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}