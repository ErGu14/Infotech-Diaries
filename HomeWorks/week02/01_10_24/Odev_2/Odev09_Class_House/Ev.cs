using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev09_Class_House
{
    internal class Ev
    {
        // Özellikler
        public string Adres { get; private set; }
        public int OdaSayisi { get; private set; }
        private decimal KiraFiyati { get; set; }

        // Yapıcı Metot
        public Ev(string adres, int odaSayisi, decimal kiraFiyati)
        {
            Adres = adres;
            OdaSayisi = odaSayisi;
            KiraFiyati = kiraFiyati;
        }

        // Kira Artırma Metodu
        public void KiraArtir(decimal miktar)
        {
            if (miktar > 0)
            {
                KiraFiyati += miktar;
                Console.WriteLine($"Kira {miktar} TL artırıldı. Güncel kira: {KiraFiyati} TL");
            }
            else
            {
                Console.WriteLine("Artış miktarı pozitif olmalıdır.");
            }
        }

        // Kira Bilgisini Yazdırma Metodu
        public void KiraBilgisiniYazdir()
        {
            Console.WriteLine($"Adres: {Adres}");
            Console.WriteLine($"Oda Sayısı: {OdaSayisi}");
            Console.WriteLine($"Güncel Kira: {KiraFiyati} TL");
        }
    }
}

