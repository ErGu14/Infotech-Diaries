using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;
        private readonly IServiceProvider _provider; // servise erişme

        public UnitOfWork(ECommerceDbContext context, IServiceProvider provider)
        {
            _context = context;
            _provider=provider;
        }

        public void Dispose()
        {
            _context.Dispose(); // veriyi silme
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return _provider.GetRequiredService<IGenericRepository<T>>(); // örnek product ile çalışıyorsam bana generic repi service den çağırıyorum 
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync(); 
        }
    }
}
