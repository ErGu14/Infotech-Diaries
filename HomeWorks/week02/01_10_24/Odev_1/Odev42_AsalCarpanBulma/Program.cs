namespace Odev42_AsalCarpanBulma
{
    internal class Program
    {
        static List<int> AsalCarpanlar(int sayi)
        {
            List<int> carpanlar = new List<int>();
            int bolen = 2;

            while (sayi > 1)
            {
                if (sayi % bolen == 0)
                {
                    carpanlar.Add(bolen);
                    sayi /= bolen;
                }
                else
                {
                    bolen++;
                }
            }

            return carpanlar;
        }

        static void Main(string[] args)
        {
            //42. Girilen bir sayının asal çarpanlarını bulan program yazın.
            Console.Write("Bir sayı giriniz: ");
            int sayi = int.Parse(Console.ReadLine());

            List<int> carpanlar = AsalCarpanlar(sayi);

            Console.WriteLine($"{sayi} sayısının asal çarpanları: {string.Join(", ", carpanlar)}");

        }
    }
}
