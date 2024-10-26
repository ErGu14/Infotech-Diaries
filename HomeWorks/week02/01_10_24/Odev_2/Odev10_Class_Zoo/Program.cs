namespace Odev10_Class_Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hayvanat Bahçesi nesnesi oluşturma
            HayvanatBahcesi hayvanatBahcesi = new HayvanatBahcesi();

            // Hayvan nesneleri oluşturma ve ekleme
            Hayvan hayvan1 = new Hayvan("Aslan", "Memeli", 5);
            Hayvan hayvan2 = new Hayvan("Tukan", "Kuş", 2);
            hayvanatBahcesi.HayvanEkle(hayvan1);
            hayvanatBahcesi.HayvanEkle(hayvan2);

            // Hayvanları listeleme
            hayvanatBahcesi.HayvanlariListele();
        }
    }
}
