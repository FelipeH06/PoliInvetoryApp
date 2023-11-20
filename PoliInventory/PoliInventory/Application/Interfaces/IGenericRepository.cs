using PoliInventory.Domain.Entities;
using System.Linq.Expressions;

namespace PoliInventory.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int id);
        void Update(T entity);
        Task<bool> SaveChanges();
    }
}
