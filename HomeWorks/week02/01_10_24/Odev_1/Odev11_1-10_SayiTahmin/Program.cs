namespace Odev11_1_10_SayiTahmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 11. 1 ile 10 arasında rastgele bir sayı üretin ve kullanıcıdan bu sayıyı tahmin etmesini isteyin.

            Random random = new Random();

            int sayi = random.Next(1,11);
            int guess = 0;

            Console.WriteLine("1 ile 10 arasında sayı tutun.\n ");
            

            while (guess != sayi) {

                Console.Write("Tahmininiz: ");
                guess = int.Parse(Console.ReadLine());

                if (guess == sayi)
                {

                    Console.WriteLine("TEBRİKLER");


                }
                else {

                    Console.WriteLine("Tekrar Deneyin");
                
                }

            
            }




        }
    }
}
