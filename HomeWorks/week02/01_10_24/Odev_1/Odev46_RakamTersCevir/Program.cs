namespace Odev46_RakamTersCevir
{
    internal class Program
    {
        static int TersCevir(int sayi)
        {
            int ters = 0;
            while (sayi > 0)
            {
                int kalan = sayi % 10; // Son basamağı al
                ters = (ters * 10) + kalan; // Ters sayıya ekle
                sayi /= 10; // Son basamağı çıkar
            }
            return ters;
        }

        static void Main(string[] args)
        {
            Console.Write("Bir sayı giriniz: ");
            int sayi = int.Parse(Console.ReadLine());

            int tersSayi = TersCevir(sayi);

            Console.WriteLine($"{sayi} sayısının ters çevrilmiş hali: {tersSayi}");
        }
    }
}
