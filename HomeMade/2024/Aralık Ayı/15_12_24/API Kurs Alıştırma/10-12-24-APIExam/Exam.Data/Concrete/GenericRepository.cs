using Exam.Data.Abstract;
using Exam.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SQLExamContext _context;
        private readonly DbSet<T> _dbset;
        

        public GenericRepository(SQLExamContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();

        }

        public async Task AddAsync(T entity)
        {
             await _dbset.AddAsync(entity);
        }

        public Task<int> CountAsync()
        {
            return _dbset.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.CountAsync(predicate);  
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.AnyAsync(predicate); // any yani uyan burada
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _dbset;

            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if(include != null)
            {
                foreach(var includes in include)
                {
                    query = query.Include(includes);
                }
            }
            if(orderBy != null)
            {

               query = orderBy(query);
            }
           return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _dbset;

            if (predicate != null)
            {
                query.Where(predicate);
            }
            if (include != null)
            {
                foreach (var includes in include)
                {
                    query = query.Include(includes);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id) // Id yi bul ve getir
        {
            return await _dbset.FindAsync(id); // bulmak
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        
    }
}
