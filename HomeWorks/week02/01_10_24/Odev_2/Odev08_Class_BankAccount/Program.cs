namespace Odev08_Class_BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
             // Banka Hesabı nesnesi oluşturma
        BankaHesabi hesap = new BankaHesabi("1234567890", "Mehmet Yılmaz", 5000);

            // Hesap bilgilerini ekrana yazdırma
            hesap.BakiyeSorgula();

            // Para yatırma ve çekme işlemleri
            hesap.ParaYatir(1500);
            hesap.ParaCek(2000);
            hesap.ParaCek(6000); // Yetersiz bakiye durumu

            // Güncel bakiyeyi sorgulama
            hesap.BakiyeSorgula();
        }
    }
}
