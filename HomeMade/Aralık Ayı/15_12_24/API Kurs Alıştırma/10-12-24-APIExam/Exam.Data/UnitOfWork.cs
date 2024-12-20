using Exam.Data.Abstract;
using Exam.Data.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SQLExamContext _context; // veri tabanını bağlicaz
        private readonly IServiceProvider _provider; // hizmetçiyi çağırıyoruz
        public UnitOfWork(SQLExamContext context, IServiceProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return _provider.GetRequiredService<IGenericRepository<T>>(); // sunucudan istekte bulununca bana Igenereic repoyu T türünde getir diyorum 
        }

        public async Task<int> SaveChangesAsync<T>()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
