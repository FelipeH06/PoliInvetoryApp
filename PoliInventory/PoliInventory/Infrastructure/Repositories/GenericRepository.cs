using Microsoft.EntityFrameworkCore;
using PoliInventory.Application.Interfaces;
using PoliInventory.Domain.Entities;
using PoliInventory.Infrastructure.Configuration;
using System.Linq.Expressions;

namespace PoliInventory.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        protected readonly DbSet<T> _entities;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entities = _appDbContext.Set<T>();

        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);   
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveChanges()
        {
            return await _appDbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        
    }
}
