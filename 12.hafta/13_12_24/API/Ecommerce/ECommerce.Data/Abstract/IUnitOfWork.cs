using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Abstract
{
    public interface IUnitOfWork : IDisposable // bellekten yok etmek demek    istediğimiz zaman bellekten veriyi silmemize işe yaricak yani veriyi yazarken birşey kayıt olmazsa bi sorun çıkarsa sorunsuz silmek için yapmaya yaricak burası
    {
        IGenericRepository<T> GetRepository<T>() where T : class; // hangi tipten bir class türde repo çağırıcaksam onu döndürcek
        Task<int> /*N Kadar satır etkilendi demek*/ SaveChangesAsync(); // kaydetme işlemi
    }
}
