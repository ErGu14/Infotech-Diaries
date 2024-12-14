using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Abstract
{
    public interface IUnitOfWork :IDisposable
    {
        //kaydetme verileri getirip götürme işlemlerini yapıcak veya kaydetme işlemi için yani veriyi yazarken birşey kayıt olmazsa bi sorun çıkarsa sorunsuz silmek için yapmaya yaricak burası
        IGenericRepository<T>  GetRepository<T>() where T : class; //class tipindeki T nin tüm repository işlemlerini serviceden getirmek
        Task<int> SaveChangesAsync();  // klasik veriyi kaydetme işlemi    oraya int koyma sepebimiz  kaç tane veriyi kaydediceksek o kadar veri kaydet demek için yani 10 tane veri değişikliği yapıp kaydediceksem ordaki int'e 10 yazılıcak ve 10 veriyi kaydet diyecek

        //şimdi bunları sürekli program çalışırken veriyi listelemek veriyi kaydetme gibi işlemler olucağı için ben her koduma teker teker şu nesneyi çağır bana dememek için her istekde bulununca tek bir nesneyi çağırayım diye program.cs e addscope diyerek nesnemi orda oluşturucam ama interface olarak yollicam ve ben ona class olarak söyleyerek manipüle edicem örnek olarak birine soyadıyla sesleniyorsun oda aslında benim adım "Eray" ama sen beni çağırdığını anladım ve işlemini yapıcam dicek  interfaceyi niye çağırmıyoruz dersek cevap olarak işlem kolaylığı diyebiliriz soyut bir şeyi çağıramayız ancak somut olan bir şeyi çağırabilir veya üstünde oynamalar yapabiliriz
    }
}
