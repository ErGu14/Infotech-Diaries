namespace Odev13_AsalSayiKontrol
{
    internal class Program
    {
        // Kullanıcıdan bir sayı alın ve bu sayının asal olup olmadığını kontrol eden program yazın.

        static bool Asal(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;

            for (int i = 2; i < Math.Sqrt(number); i++) { 

                if (number % i == 0) return false;
            


            }
            return true;

        }


        static void Main(string[] args)
        {
            Console.Write("sayı giriniz : ");
            int sayi = int.Parse(Console.ReadLine());

            if (Asal(sayi)) {

                Console.WriteLine($"{sayi} bir asal sayıdır.");


            }
            else
            {
                Console.WriteLine($"{sayi} bir asal sayı değildir.");
            }

        } 
    }
}
