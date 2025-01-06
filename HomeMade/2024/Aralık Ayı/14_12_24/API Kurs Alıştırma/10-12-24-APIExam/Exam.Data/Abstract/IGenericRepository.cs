using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id); // tek bir veriyi getirecek

        //koşulu uygunsa getir (uyan hepsini ve örnek içinde kategori miras alınmışsa vs onlarla beraber getir)
        Task<T> GetAsync(Expression<Func<T,bool>> predicate,params Expression<Func<T, object>>[] includes);

        //istisnasız her şeyi getir  (birden fazla veri olacağı için bir liste türü olan ve performansı yüksek Ienumerable kullanıyoruz)
        Task<IEnumerable<T>> GetAllAsync();

        // koşula göre ve istediğim şekilde listelemek için  yani örnek : aktif olan ürünleri a-z sırala ve ona bağlı kategori adlarıyla beraber listeli şekilde getir
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>>? predicate =null,Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy=null,params Expression<Func<T, object>>[] include);


        Task<T> FindAsync(Expression<Func<T,bool>> predicate); //koşulu uyan tek bir veriyi getir demek
        Task<bool> ExixstAsync(Expression<Func<T,bool>> predicate); // varlığını kontrol ediyoruz örnek veriyorum verilerimde elma var mı yokmu onu kontrol ediyorum varsa true yoksa false dönecek

        
        Task Add(T entity); //Veri ekleme
        void Update(T entity); // tek seferlik çalışacağı için void
        void Delete(T entity); //tek seferlik çalışacağı için void

        
        Task<int> CountAsync();//verileri sayma (aktif olan olmayan her şeyi sayar)
        Task<int> CountAsync(Expression<Func<T, bool>> predicate); // koşula uygun verileri sayma   örnek kategori Id si 4 olan her ürünü say demek
    }
}
