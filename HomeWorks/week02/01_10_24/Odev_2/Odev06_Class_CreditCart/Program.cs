namespace Odev06_Class_CreditCart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kredi Kartı nesnesi oluşturma
            KrediKarti krediKarti = new KrediKarti("1234 5678 9012 3456", "12/25", "123");

            // Kart bilgilerini ekrana yazdırma
            krediKarti.KartBilgileriniYazdir();
        }
    }
}
