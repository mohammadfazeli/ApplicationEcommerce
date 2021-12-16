using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entites;

namespace Core.InterFace
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IList<Product>> GetProductsAsync();

    }
}