
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev06_Class_CreditCart
{
    internal class KrediKarti
    {
        // Özellikler
        private string KartNumarasi { get; set; }
        public string SonKullanmaTarihi { get; set; }
        private string CVV { get; set; }

        // Yapıcı Metot
        public KrediKarti(string kartNumarasi, string sonKullanmaTarihi, string cvv)
        {
            KartNumarasi = kartNumarasi;
            SonKullanmaTarihi = sonKullanmaTarihi;
            CVV = cvv;
        }

        // Kart Bilgilerini Yazdırma Metodu
        public void KartBilgileriniYazdir()
        {
            Console.WriteLine($"Kart Numarası: {KartNumarasi}");
            Console.WriteLine($"Son Kullanma Tarihi: {SonKullanmaTarihi}");
            Console.WriteLine($"CVV: {CVV}");
        }
    }
}
