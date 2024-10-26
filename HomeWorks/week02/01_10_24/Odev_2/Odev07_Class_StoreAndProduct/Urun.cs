using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev07_Class_StoreAndProduct
{
    internal class Urun
    {
        // Özellikler
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int Stok { get; set; }

        // Yapıcı Metot
        public Urun(string urunAdi, decimal fiyat, int stok)
        {
            UrunAdi = urunAdi;
            Fiyat = fiyat;
            Stok = stok;
        }
    }

}

