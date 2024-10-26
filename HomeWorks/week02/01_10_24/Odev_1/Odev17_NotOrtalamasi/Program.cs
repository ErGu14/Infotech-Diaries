namespace Odev17_NotOrtalamasi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Bir öğrencinin not ortalamasını hesaplayan bir program yazın.

            Console.Write("Birinci sınav notunu girin: ");
            double sinav1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("İkinci sınav notunu girin: ");
            double sinav2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Birinci performans notunu girin: ");
            double performans1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("İkinci performans notunu girin: ");
            double performans2 = Convert.ToDouble(Console.ReadLine());

            
            double ortalama = (sinav1 + sinav2 + performans1 + performans2) / 4;

            
            Console.WriteLine("Not ortalaması: " + ortalama);
        }
    }
}
