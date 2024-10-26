using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev01_Class_Library
{
    internal class Kitap
    {
        // Özellikler
        public string KitapAdi { get; set; }
        public string YazarAdi { get; set; }
        private int SayfaSayisi { get; set; }
        private int BasimYili { get; set; }

         //Yapıcı Metot
        public Kitap(string kitapAdi, string yazarAdi, int sayfaSayisi, int basimYili)
        {
            KitapAdi = kitapAdi;
            YazarAdi = yazarAdi;
            SayfaSayisi = sayfaSayisi;
            BasimYili = basimYili;
        }

        // DisplayInfo Metodu
        public void DisplayInfo()
        {
            Console.WriteLine($"Kitap Adı: {KitapAdi}");
            Console.WriteLine($"Yazar Adı: {YazarAdi}");
            Console.WriteLine($"Sayfa Sayısı: {SayfaSayisi}");
            Console.WriteLine($"Basım Yılı: {BasimYili}");
        }
    }
}
