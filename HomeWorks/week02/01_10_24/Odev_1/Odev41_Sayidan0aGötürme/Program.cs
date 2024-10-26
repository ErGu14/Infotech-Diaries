namespace Odev41_Sayidan0aGötürme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 41- Kullanıcının girdiği bir sayıdan geriye doğru sıfıra kadar sayan program yazın.

            Console.Write("Bir sayı giriniz: ");
            int sayi = int.Parse(Console.ReadLine());

            Console.WriteLine($"{sayi} sayısından geriye doğru sayma:");

            for (int i = sayi; i >= 0; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
