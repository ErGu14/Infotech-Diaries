using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev_05_Class_Musteri
{
    internal class Siparis
    {
        // Özellikler
        public string SiparisAdi { get; set; }
        public decimal Fiyat { get; set; }

        // Yapıcı Metot
        public Siparis(string siparisAdi, decimal fiyat)
        {
            SiparisAdi = siparisAdi;
            Fiyat = fiyat;
        }
    }
}
