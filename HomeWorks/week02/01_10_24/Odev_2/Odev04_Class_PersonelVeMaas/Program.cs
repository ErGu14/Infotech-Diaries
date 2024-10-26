namespace Odev04_Class_PersonelVeMaas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personel personel = new Personel("Ahmet", "Yılmaz", 3500);

            // Personel bilgilerini ekrana yazdırma
            personel.MaasYazdir();

            // Maaşı artırma
            personel.MaasArtir(500);

            // Güncel maaşı yazdırma
            personel.MaasYazdir();
        }
    }
}
