namespace Odev38_FibonacciKontrol
{
    internal class Program
    {
        static bool FibonacciMi(int sayi)
        {
           
            int a = 0;
            int b = 1;

            
            if (sayi == a || sayi == b)
            {
                return true;
            }

            
            int c = a + b;
            while (c <= sayi)
            {
                if (c == sayi)
                {
                    return true;
                }
                a = b;
                b = c;
                c = a + b;
            }

            return false;
        }

        static void Main(string[] args)
        {

            //38. Kullanıcının girdiği bir sayının Fibonacci serisinde olup olmadığını kontrol eden program yazın.


            Console.Write("Bir sayı giriniz: ");
            int sayi = int.Parse(Console.ReadLine());

            if (FibonacciMi(sayi))
            {
                Console.WriteLine($"{sayi} Fibonacci serisindedir.");
            }
            else
            {
                Console.WriteLine($"{sayi} Fibonacci serisinde değildir.");
            }
        }

    }
}
