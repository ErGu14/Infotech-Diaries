using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev04_Class_PersonelVeMaas
{
    public class Personel
    {
        // Özellikler
        public string Ad { get; private set; }
        public string Soyad { get; private set; }
        private decimal Maas { get; set; }

        // Yapıcı Metot
        public Personel(string ad, string soyad, decimal maas)
        {
            Ad = ad;
            Soyad = soyad;
            MaasAyarla(maas);
        }

        // Maaş Ayarlama Metodu
        public void MaasAyarla(decimal maas)
        {
            if (maas >= 3000)
            {
                Maas = maas;
            }
            else
            {
                Console.WriteLine("Maaş 3000'den az olamaz.");
            }
        }

        // Maaş Artırma Metodu
        public void MaasArtir(decimal miktar)
        {
            Maas += miktar;
            Console.WriteLine($"Yeni maaş: {Maas} TL");
        }

        // Güncel Maaşı Yazdırma Metodu
        public void MaasYazdir()
        {
            Console.WriteLine($"Personel: {Ad} {Soyad}, Güncel Maaş: {Maas} TL");
        }
    }
}