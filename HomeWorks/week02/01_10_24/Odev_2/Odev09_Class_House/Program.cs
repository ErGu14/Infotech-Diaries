namespace Odev09_Class_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ev nesnesi oluşturma
            Ev ev = new Ev("İstanbul, Beyoğlu", 3, 5000);

            // Ev bilgilerini ekrana yazdırma
            ev.KiraBilgisiniYazdir();

            // Kira artırma
            ev.KiraArtir(500);

            // Güncel kira bilgisini yazdırma
            ev.KiraBilgisiniYazdir();
        }
    }
}
