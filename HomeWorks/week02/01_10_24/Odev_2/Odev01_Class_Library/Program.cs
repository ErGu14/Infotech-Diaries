namespace Odev01_Class_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kitap nesnesi oluşturma
            Kitap kitap = new Kitap("Sefiller", "Victor Hugo", 1232, 1862);

            // Kitap bilgilerini ekrana yazdırma
            kitap.DisplayInfo();
        }
    }
}
