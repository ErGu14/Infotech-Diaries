using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete.Contexts;
using ECommerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Concrete.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ECommerceDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ECommerceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);//entity şu an EF Core tarafından takip ediliyor!
            return entity;
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }


        //x=>x.CategoryId==1
        //x=>x.Price>=100 && x.Price<=200
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate);
            //return await _dbSet.Where(predicate).CountAsync();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            //_dbSet.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }


        //x=>x.Price==56 && x.IsActive==true && x.CreatedDate==DateTime.Now
        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? take = null,
            params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includes != null)
            {
                query = includes.Aggregate(
                    query,
                    (current, include) => include(current));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (take.HasValue)
            {
                query = query.Skip(0).Take(take.Value);
            }

            return await query.ToListAsync();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includes != null)
            {
                query = includes.Aggregate(
                    query,
                    (current, include) => include(current));
            }
            return query.FirstOrDefaultAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            //_dbSet.Entry(entity).State = EntityState.Modified;
        }
    }
}
