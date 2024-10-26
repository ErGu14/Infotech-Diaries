namespace Odev24_DiziOrtalamaVeToplama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 24. Bir dizi içerisindeki tüm elemanların toplamını ve ortalamasını hesaplayan program yazın.

            int[] list = { 10, 20, 30, 40, 50 };

            
            int toplam = 0;
            double ortalama;

            
            foreach (int sayi in list)
            {
                toplam += sayi;
            }

            
            ortalama = (double)toplam / list.Length;

           
            Console.WriteLine("Dizinin Toplamı: " + toplam);
            Console.WriteLine("Dizinin Ortalaması: " + ortalama);
        }
    }
}
