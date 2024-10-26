namespace Odev33_2SayiTopla1Arttir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  33. Kullanıcının girdiği iki sayıyı toplarken her iki sayıyı da 1 artırıp tekrar toplama yapan programı yazın.

            Console.Write("Birinci sayıyı giriniz: ");
            int sayi1 = int.Parse(Console.ReadLine());

            Console.Write("İkinci sayıyı giriniz: ");
            int sayi2 = int.Parse(Console.ReadLine());

            
            int toplam1 = sayi1 + sayi2;
            Console.WriteLine($"İlk toplama sonucu: {toplam1}");

            
            sayi1++;
            sayi2++;

            
            int toplam2 = sayi1 + sayi2;
            Console.WriteLine($"İkinci toplama sonucu (her iki sayı 1 artırıldıktan sonra): {toplam2}");
        }
    }
}
