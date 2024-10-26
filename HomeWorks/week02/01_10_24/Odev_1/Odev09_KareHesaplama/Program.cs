namespace Odev09_KareHesaplama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 9. Kullanıcıdan bir sayı alın ve bu sayının karesini hesaplayıp ekrana yazdırın.

            Console.Write("Sayı giriniz: ");
            long a = long.Parse(Console.ReadLine());
            Console.WriteLine($"Sayınızın Karesi : {a*a}");
        }
    }
}
