using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<T> GetAsync(Expression<Func<T,bool>> predicate,params Expression<Func<T, object>>[] include);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Expression<Func<IQueryable<T>, IOrderedQueryable<T>>>? orderBy = null, params Expression<Func<T, object>>[] include);

        Task<T> FindAsync(Expression<Func<T,bool>> predicate);
        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
