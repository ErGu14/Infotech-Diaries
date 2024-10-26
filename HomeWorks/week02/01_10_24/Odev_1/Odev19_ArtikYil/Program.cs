namespace Odev19_ArtikYil
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 19. Bir yılın artık yıl olup olmadığını kontrol eden programı yazın.

            Console.Write("Kontrol etmek istediğiniz yılı girin: ");
            int yil = int.Parse(Console.ReadLine());

            if (DateTime.IsLeapYear(yil)) // 
            {
                Console.WriteLine($"{yil} yılı artık yıldır.");
            }
            else
            {
                Console.WriteLine($"{yil} yılı artık yıl değildir.");
            }
        }
    }
}
