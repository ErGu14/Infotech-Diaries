using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev_05_Class_Musteri
{
    internal class Musteri
    {
        // Özellikler
        public string Ad { get; set; }
        public string Soyad { get; set; }
        private List<Siparis> Siparisler { get; set; }

        // Yapıcı Metot
        public Musteri(string ad, string soyad)
        {
            Ad = ad;
            Soyad = soyad;
            Siparisler = new List<Siparis>();
        }
        public void SiparisEkle(Siparis siparis)
        {
            Siparisler.Add(siparis);
        }

        // Toplam Sipariş Tutarını Hesaplama Metodu
        public decimal ToplamSiparisTutari()
        {
            decimal toplam = 0;
            foreach (var siparis in Siparisler)
            {
                toplam += siparis.Fiyat;
            }
            return toplam;
        }

        // Sonuçları Görüntüleme Metodu
        public void DisplayResult()
        {
            Console.WriteLine($"Müşteri: {Ad} {Soyad}");
            Console.WriteLine($"Toplam Sipariş Tutarı: {ToplamSiparisTutari()} TL");
        }
    }
}
