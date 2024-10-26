using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev07_Class_StoreAndProduct
{
    internal class Magaza
    {
        // Özellikler
        private List<Urun> Urunler { get; set; }

        // Yapıcı Metot
        public Magaza()
        {
            Urunler = new List<Urun>();
        }

        // Ürün Ekleme Metodu
        public void UrunEkle(Urun urun)
        {
            Urunler.Add(urun);
        }

        // Stoktaki Ürünleri Listeleme Metodu
        public void StoktakiUrunleriListele()
        {
            Console.WriteLine("Stoktaki Ürünler:");
            foreach (var urun in Urunler)
            {
                Console.WriteLine($"Ürün Adı: {urun.UrunAdi}, Fiyat: {urun.Fiyat} TL, Stok: {urun.Stok}");
            }
        }

        // Ürün Satma ve Stok Güncelleme Metodu
        public void UrunSat(string urunAdi, int miktar)
        {
            var urun = Urunler.Find(u => u.UrunAdi == urunAdi);
            if (urun != null)
            {
                if (urun.Stok >= miktar)
                {
                    urun.Stok -= miktar;
                    Console.WriteLine($"{miktar} adet {urunAdi} satıldı. Kalan stok: {urun.Stok}");
                }
                else
                {
                    Console.WriteLine("Yeterli stok yok.");
                }
            }
            else
            {
                Console.WriteLine("Ürün bulunamadı.");
            }
        }
    }
}
