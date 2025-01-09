using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete.Contexts;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(ECommerceDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<IGenericRepository<T>>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
