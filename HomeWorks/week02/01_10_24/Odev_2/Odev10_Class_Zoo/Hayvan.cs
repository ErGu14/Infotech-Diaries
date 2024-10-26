using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev10_Class_Zoo
{
    internal class Hayvan
    {
        // Özellikler
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }

        // Yapıcı Metot
        public Hayvan(string ad, string tur, int yas)
        {
            Ad = ad;
            Tur = tur;
            Yas = yas;
        }
    }
}
