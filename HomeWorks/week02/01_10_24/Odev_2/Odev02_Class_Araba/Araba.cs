using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev02_Class_Araba
{
    internal class Araba
    {
        public string Marka { get; private set; }
        public int ModelYili { get; private set; }
        public int Kilometre { get; private set; }
        public double YakitDurumu { get; private set; }

        // Yapıcı Metot
        public Araba(string marka, int modelYili)
        {
            Marka = marka;
            ModelYili = modelYili;
            Kilometre = 0; // Yeni araba, kilometre sıfırdan başlar
            YakitDurumu = 100; // Yeni araba, yakıt deposu dolu
        }

        public void Sur(int mesafe)
        {
            if (YakitDurumu > 0)
            {
                Kilometre += mesafe;
                YakitDurumu -= mesafe * 0.1; // Her 10 km'de 1 birim yakıt tüketimi
                if (YakitDurumu < 0)
                    YakitDurumu = 0;
                Console.WriteLine($"{mesafe} km sürüldü. Toplam kilometre: {Kilometre}, Kalan yakıt: {YakitDurumu}%");
            }
            else
            {
                Console.WriteLine("Yeterli yakıt yok. Lütfen yakıt alın.");
            }
        }

        // CheckFuel Metodu
        public void YakitKontrol()
        {
            Console.WriteLine($"Kalan yakıt: {YakitDurumu}%");
        }
    }
}


