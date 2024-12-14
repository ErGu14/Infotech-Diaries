using Exam.Data.Abstract;
using Exam.Data.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SQLExamContext _context;
        private readonly IServiceProvider _provider;

        public UnitOfWork(SQLExamContext context, IServiceProvider provider)
        {
            _context = context;
            _provider = provider; // servise ulaşmak çünkü yaptığımız her işlem servise gidicek ve servisten databaseye gidecek
        }

        public void Dispose() // veri silme işlemi
        {
            _context.Dispose();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class // T Tipinde olan tüm repositoryleri getir (repository dediğimiz işte hepsini getirme id ile geitmr vs)
        {
            return _provider.GetRequiredService<IGenericRepository<T>>(); // serviste istekte bulunulduğu zaman IGenericRepository olarak T tipinde veriyi getir (örnek veriyorum buradaki T Product olsun => Productın tüm IGenericRepository İşlemlerini Getir)
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync(); // veri tabanına kaydet
        }

        // silme ve kaydetme işlemleri veri tabanına özgü bir şey Rpositoryleri getirmek ise servisin yani hizmetçinin işi


    }
}
