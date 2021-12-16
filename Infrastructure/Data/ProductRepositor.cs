using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entites;
using Core.InterFace;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _db;

        public ProductRepository(StoreContext db)
        {
            _db = db;
        }
        
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }
    }
}