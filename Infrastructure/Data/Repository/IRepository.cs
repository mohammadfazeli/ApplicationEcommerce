using Core.Entites;
using Core.Specefication;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetAync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAync(ISpecefication<T> specefication);
        Task<List<T>> GetAllAsync(ISpecefication<T> specefication);

    }
}