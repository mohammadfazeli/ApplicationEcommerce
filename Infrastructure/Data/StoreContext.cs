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
        public DbSet<Product> prodducts { get; set; }

        #endregion
    }
}