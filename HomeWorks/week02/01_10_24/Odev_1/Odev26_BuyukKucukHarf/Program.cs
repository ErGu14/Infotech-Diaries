namespace Odev26_BuyukKucukHarf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 26.Girilen bir cümledeki büyük ve küçük harf sayısını bulan program yazın.

            Console.Write("Bir cümle giriniz : ");
            string cumle = Console.ReadLine();

            int buyukHarfSayisi = 0;
            int kucukHarfSayisi = 0;

            
            foreach (char harf in cumle)
            {
                if (char.IsUpper(harf))
                {
                    buyukHarfSayisi++;
                }
                else if (char.IsLower(harf))
                {
                    kucukHarfSayisi++;
                }
            }

            
            Console.WriteLine("\nCümledeki büyük harf sayısı: " + buyukHarfSayisi);
            Console.WriteLine("\nCümledeki küçük harf sayısı: " + kucukHarfSayisi);
        }
    }
}
