using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev03_Class_Ogrenci
{
    internal class Ogrenci
    {
        // Özellikler
        public string Ad { get; set; }
        public string Soyad { get; set; }
        private int[] Notlar { get; set; }

        // Yapıcı Metot
        public Ogrenci(string ad, string soyad)
        {
            Ad = ad;
            Soyad = soyad;
            Notlar = new int[3];
        }

        // Not Ekleme Metodu
        public void NotEkle(int dersIndex, int not)
        {
            if (dersIndex >= 0 && dersIndex < Notlar.Length)
            {
                Notlar[dersIndex] = not;
            }
            else
            {
                Console.WriteLine("Geçersiz ders indexi.");
            }
        }

        // Ortalama Hesaplama Metodu
        public double OrtalamaHesapla()
        {
            int toplam = 0;
            foreach (int not in Notlar)
            {
                toplam += not;
            }
            return (double)toplam / Notlar.Length;
        }

        // Sonuçları Görüntüleme Metodu
        public void DisplayResult()
        {
            double ortalama = OrtalamaHesapla();
            Console.WriteLine($"Öğrenci: {Ad} {Soyad}");
            Console.WriteLine($"Ortalama: {ortalama}");
            if (ortalama >= 50)
            {
                Console.WriteLine("Geçti");
            }
            else
            {
                Console.WriteLine("Kaldı");
            }
        }

    }
}