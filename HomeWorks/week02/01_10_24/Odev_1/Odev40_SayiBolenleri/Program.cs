namespace Odev40_SayiBolenleri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //40. Girilen bir sayının tam bölenlerini bulan program yazın.

            Console.Write("Bir sayı giriniz: ");
            int sayi = int.Parse(Console.ReadLine());

            Console.WriteLine($"{sayi} sayısının tam bölenleri:");

            for (int i = 1; i <= sayi; i++)
            {
                if (sayi % i == 0)
                {
                    Console.WriteLine(i);
                }
    }
        }
    }
}
