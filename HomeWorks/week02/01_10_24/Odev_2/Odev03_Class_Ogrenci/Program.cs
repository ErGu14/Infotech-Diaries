namespace Odev03_Class_Ogrenci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Öğrenci nesnesi oluşturma
            Ogrenci ogrenci = new Ogrenci("Ali", "Yılmaz");

            // Öğrenciye not ekleme
            ogrenci.NotEkle(0, 70);
            ogrenci.NotEkle(1, 85);
            ogrenci.NotEkle(2, 90);

            // Öğrenci sonuçlarını ekrana yazdırma
            ogrenci.DisplayResult();
        }
    }
}
