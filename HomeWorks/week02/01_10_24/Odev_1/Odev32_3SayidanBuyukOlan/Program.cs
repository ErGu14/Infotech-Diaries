
namespace Odev32_3SayidanBuyukOlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //

            // Kullanıcıdan üç sayı al
            Console.Write("Birinci sayıyı giriniz: ");
            int sayi1 = int.Parse(Console.ReadLine());

            Console.Write("İkinci sayıyı giriniz: ");
            int sayi2 = int.Parse(Console.ReadLine());

            Console.Write("Üçüncü sayıyı giriniz: ");
            int sayi3 = int.Parse(Console.ReadLine());

            // En büyük sayıyı bul
            int enBuyuk = Math.Max(Math.Max(sayi1, sayi2), sayi3);

            // Sonucu ekrana yazdır
            Console.WriteLine($"Girilen sayılardan en büyüğü: {enBuyuk}");
        }
    }
}
