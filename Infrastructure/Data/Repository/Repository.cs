using Core.Entites;
using Core.Specefication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly DbSet<T> _dbset;
        private readonly StoreContext _storeContext;

        public Repository(StoreContext storeContext)
        {
            _storeContext = storeContext;
            _dbset = _storeContext.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(ISpecefication<T> specefication)
        {
            return await ApplySpecefication(specefication).ToListAsync();
            
        }

        public async Task<T> GetAync(int id)
        {
            return await _dbset.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<T> GetAync(ISpecefication<T> specefication)
        {
            return await ApplySpecefication(specefication).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecefication(ISpecefication<T> specefication)
        {
            return SpeceficationEveluator<T>.GetQuery(_dbset.AsQueryable(), specefication);
        }
    }
}