namespace Odev18_UcgenOrnekleri
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //18. Bir üçgenin kenar uzunluklarını alarak bu üçgenin eşkenar, ikizkenar veya çeşitkenar olup olmadığını belirleyen program yazın.

            Console.Write("Birinci kenar uzunluğunu girin: ");
            int kenar1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("İkinci kenar uzunluğunu girin: ");
            int kenar2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Üçüncü kenar uzunluğunu girin: ");
            int kenar3 = Convert.ToInt32(Console.ReadLine());

            
            if (kenar1 == kenar2 && kenar2 == kenar3)
            {
                Console.WriteLine("Bu üçgen eşkenar üçgendir.");
            }
            else if (kenar1 == kenar2 || kenar1 == kenar3 || kenar2 == kenar3)
            {
                Console.WriteLine("Bu üçgen ikizkenar üçgendir.");
            }
            else
            {
                Console.WriteLine("Bu üçgen çeşitkenar üçgendir.");
            }
        }
    }
}
