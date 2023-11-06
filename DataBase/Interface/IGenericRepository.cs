using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(List<T> entities);
        bool Any(Expression<Func<T, bool>> expression);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

       

    }
}
