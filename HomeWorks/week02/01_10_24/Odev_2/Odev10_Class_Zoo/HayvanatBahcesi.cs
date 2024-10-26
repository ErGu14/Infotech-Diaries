using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev10_Class_Zoo
{
    internal class HayvanatBahcesi
    {
        // Özellikler
        private List<Hayvan> Hayvanlar { get; set; }

        // Yapıcı Metot
        public HayvanatBahcesi()
        {
            Hayvanlar = new List<Hayvan>();
        }

        // Hayvan Ekleme Metodu
        public void HayvanEkle(Hayvan hayvan)
        {
            Hayvanlar.Add(hayvan);
        }

        // Hayvanları Listeleme Metodu
        public void HayvanlariListele()
        {
            Console.WriteLine("Hayvanat Bahçesindeki Hayvanlar:");
            foreach (var hayvan in Hayvanlar)
            {
                Console.WriteLine($"Ad: {hayvan.Ad}, Tür: {hayvan.Tur}, Yaş: {hayvan.Yas}");
            }
        }
    }
}
