using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
        private readonly DbSet<T> _dbset;

       

        public GenericRepository(ECommerceDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>(); 
        }

        public async Task<T> AddAsync(T entity)
        {
           await _dbset.AddAsync(entity);// burdaki t neyse dbsetteki veriyi buraya alıp yapıcak    async işaretlenen bir metoda await yazmalıyız  // entity şuan EF core tarafından takip ediliyor
            return entity; 


        }

        public async Task<int> CountAsync()
        {
            return await _dbset.CountAsync();
        }


        // x => x.CategoryId = 1
        
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.CountAsync(predicate); // verilen koşula göre sayma misali kodun üstündeki ıd si 1 olan kategorileri sayma 
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public async Task<bool> ExixstAsync(Expression<Func<T, bool>> predicate)
        {
            // sana verdiğim kriterlere göre yani sana diceğim bir şartın olup olmadığını kontrol etmek amaçlı bir yer
            return await _dbset.AnyAsync(predicate);

        }

        //find asyn deseydim rpimary key aricaktı ama bu yazdığımızda söylenen koşula göre arama yapıcaktır
        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            //arama
            return await _dbset.FirstOrDefaultAsync(predicate);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }



        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null, 
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbset; // producta göre = _context.Products

            if (predicate != null)
            {
                query = query.Where(predicate); //bunu ekle, buda ==>  _context.Procuts.Where(x =>x.CategoryId == 1) demek
            }
            if (includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);

            }
            return await query.ToListAsync();

        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbset; //örtülü dönüştürme
            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if(includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
    }
}
