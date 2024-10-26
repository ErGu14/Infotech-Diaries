namespace Odev22_KelimeSayisi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 22.Girilen bir cümledeki kelime sayısını bulan program yazın.

            Console.Write("Bir cümle girin: ");
            string cumle = Console.ReadLine();

            
            string[] kelimeler = cumle.Split(' ');

            
            Console.WriteLine("Kelime sayısı: " + kelimeler.Length);

        }
    }
}
