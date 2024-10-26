namespace Odev_05_Class_Musteri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Müşteri nesnesi oluşturma
            Musteri musteri = new Musteri("Ayşe", "Kara");

            // Sipariş nesneleri oluşturma ve ekleme
            Siparis siparis1 = new Siparis("Laptop", 7500);
            Siparis siparis2 = new Siparis("Telefon", 3500);
            musteri.SiparisEkle(siparis1);
            musteri.SiparisEkle(siparis2);

            // Müşteri sonuçlarını ekrana yazdırma
            musteri.DisplayResult();
        }
    }
}
