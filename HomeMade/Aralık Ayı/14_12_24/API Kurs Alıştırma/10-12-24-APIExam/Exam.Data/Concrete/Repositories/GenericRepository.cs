using Exam.Data.Abstract;
using Exam.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Concrete.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class  // interfacede kemik yapımızı oluşturduktan sonra burda ekleme  yapıcaz nasıl bir ekleme mi ? =>  interfacedeki işlemleri databasemize bağlicaz   :: Şimdi koddaki adımları açıklayalım     1- GenericRepository<T> = örnek product tipindeki tüm veri işlemlerini getir 2-IGenericRepository<T> where T : class = örnek üzerinden diyelim product tiğinde bir interface getir ve bu interfacenin veri tipi clas olucak
    {
        private readonly SQLExamContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(SQLExamContext context)
        {
            _context = context; // veri tabanına erişim
            _dbSet = _context.Set<T>();  // bu işlem ise burada yapacağım kaydetme işlemleri vs vs hangi tabloya etki edeceğini belirtiyoruz
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity); // burası bildiğimiz gibi veri ekleme yerimiz
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync(); // burası koşulsuz dediğim verilerin tümünü saymak
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate); // koşula uygun verileri saymak örnek veriyorum  id si 4 olan verileri say demek (bunu nerden kullanırsın misal stok takip eklersin ve dersin ki benim bu ürünümden kaç tane var demek için)
        }

        public async void Delete(T entity)
        {
            _dbSet.Remove(entity); // async olmicak çünkü çok küçük bir işlem verileri durdurmicak akışı bozmicak 
        }

        public async Task<bool> ExixstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate); // örnek veriyorum dicem ki  elma verisini çağırıcam var mı yok mu onun kontrolünü sağlıyorum
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate); // elma dediğim zaman bana elmayı getir demek için (eğer elmanın bir değeri uymuyorsa farketmeksizin olduğu değerle getirmek için yani illa bu koşulu net olmassa sakın getirmde değil olmasa bile ama dediğim şeyi anımmsatıyorsa yani dediğim şeye 1 dediysem program 2 dediyse onu çağırması için bu sayede hata vs varsa bunu rahatça görebilirim)
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync(); // tüm verileri getirmek örnek ürünlerin hepsini getirmek
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _dbSet; // Iqueryable nesnesini çağırma sebebimiz  ben dicem ki örnek bana işte sadece productları getir dicem yani belirli bir koşul vererek getircem içinede _dbset diyerek işte ürünler tablosunu göndericem     Bu arada sonuna <T> eklemeyi unuttum ınu eklememizin sebebi  çekeceğimiz verinin tipini belirtmek için _Dbset ile bunun bilgisini contexteki ona uyan databaseden al demek    kısaca ilgili tablonun bilgilerini query e at



            if (predicate != null) {
                
                query = query.Where(predicate); // x => x.ProductId == 1  gibi gibi
            }
            if (include != null) { 
                foreach(var includes in include)
                {
                    query = query.Include(includes); // örnek verelim ben bir tablodaki verileri getiricem ve bu tablodaki bilgilerin bide kategorilerini,dağıtımcısı gibi (örnek) diğer tablo bilgilerinide çekmek istiyorum . Am örnek veriyorum 100 tane tablo çekmem lazımsa tek tek ekle demektense ona ne kadar bağlıysa dolaş ve ekle diyorum bu vesileyle
                }
                

            }
            if (orderBy != null)
            {
                query = orderBy(query); // eğer diyorsam ki  ben ürünler tablosunu a-z olarak sıralayıp listelemek istiyorum. Eğer bunu belirtirsem ve nulldan çıkarırsam burası çalışıcak ama demezsem burası çalışmicak    query yi düzenli sıralama
            }

             return await query.ToListAsync(); // query dememizin sebebi tüm verileri query'e attığımız için düz mantık   burası ise async olarak listleyip gelen değeri döndürcek
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {

           // yukardakinin aynısı bunun amacı ise koşulu uyanları getir demek örnek veriyorum kategori ID si 3 olan ürünleri bana getir dicez herhangi bir a-z gibi listeleme yapmicaz he istersek böyle bir şeyi yukardaki gibi ekleyebiliriz 

            IQueryable<T> query = _dbSet; // T tipindeki listeyi _dbset ten al

            if (predicate != null) { 

                query.Where(predicate);
            }
            if (includes != null) {

                foreach (var include in includes)
                {
                    query = query.Include(include);

                }
            }
            return await query.FirstOrDefaultAsync(); // bu kodun anlamı eğer kod uygunsa yani kategorisi elektroin olanları getirdi diyelim ama bir üründe adında veya başka bilgisinde null vs varsa onlarıda getiriyor yani kendi belirlediği veriyle bile olsa bunu çağrıştırıyorsa onuda getir diyoruz
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id); // kategori ID si 4 olanı getir veya veri tabanında Idsi 5 olanı getir (en sondaki dediğim daha olanaklı)
            
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
