using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Abstract
{
    public interface IGenericRepository<T> where T : class // tüm claslarıma  repositorylerimizi oluşturmak için yaptığımız bir çalışma türü  içine T alan bir class olucak demek 
    {
        Task<T> GetByIdAsync(int id); // id'sine göre T getir gibi???
        Task<T> GetAsync(Expression<Func<T,bool>>predicate,params Expression<Func<T,object>>[] includes);// örnek verirsek bir ürünü getirirken kategorisinide getirmek iiçin kullandığımız bir metod    predicate   =  Categories.Where(x => x.Id ==4)  (parantez içindeki predicate)   t ise categories    bool ise içinde == içeren işlem     params demek buaya gelen şeyler birden fazla olabilir demek        diğerleride t nin alacğı tip object olcak ve yanına [] koyarak çoğulluğunu belirtiyorum    includes ise zorunlu isim değildir ama işimizi anlayalım diye yazdığımız isim    getasync kısada ilişki kurması gereken başka tablo varsa onla getirmek

        Task<IEnumerable<T>> GetAllAsync(); //IEnumerable projemiz büyürse işlemleri döngü kurabilmemize yarıyan bir metot ama bunda index numarası yok liste gibi verinin ihtiyaca göre çekilmesi demek   Ienumarable performans arttırmış oluruz

       //Iqueryable sorguyu exacute etmeden listelemek gibi işlemleri devam ettiren    burda koşula göre sıralama ne bileyim silinen tüm kayıtları getir veya silinmemiş kayıtları getirmek

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] includes);  // params demek  (x => x.Include(y => y.Category))  2. kere Include(z=>z.Include(k => k.Supplier)) ekleyebilirim

        // bir entitiy i varmı yok mu diye aramak için :

        Task<T> FindAsync(Expression<Func<T,bool>> predicate);
        Task<bool> ExixstAsync(Expression<Func<T,bool>> predicate);

        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate); //önek kategori ID si 3 olan ürünleri say demek gibi



    }
}
