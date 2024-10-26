using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev08_Class_BankAccount
{
    internal class BankaHesabi
    {
        // Özellikler
        public string HesapNumarasi { get; private set; }
        public string HesapSahibi { get; private set; }
        private decimal Bakiye { get; set; }

        // Yapıcı Metot
        public BankaHesabi(string hesapNumarasi, string hesapSahibi, decimal baslangicBakiyesi)
        {
            HesapNumarasi = hesapNumarasi;
            HesapSahibi = hesapSahibi;
            Bakiye = baslangicBakiyesi;
        }

        // Para Yatırma Metodu
        public void ParaYatir(decimal miktar)
        {
            if (miktar > 0)
            {
                Bakiye += miktar;
                Console.WriteLine($"{miktar} TL yatırıldı. Güncel bakiye: {Bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yatırılacak miktar pozitif olmalıdır.");
            }
        }

        // Para Çekme Metodu
        public void ParaCek(decimal miktar)
        {
            if (miktar > 0)
            {
                if (Bakiye >= miktar)
                {
                    Bakiye -= miktar;
                    Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye.");
                }
            }
            else
            {
                Console.WriteLine("Çekilecek miktar pozitif olmalıdır.");
            }
        }
        public void BakiyeSorgula()
        {
            Console.WriteLine($"Güncel bakiye: {Bakiye} TL");
        }
    }
}

