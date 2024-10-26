namespace Odev27_TersCumle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //27. Bir diziyi tersten yazdıran programı yazın.

            Console.WriteLine("Dizinin boyutunu giriniz:");
            int boyut = int.Parse(Console.ReadLine());

            // Diziyi tanımlıyoruz ve kullanıcıdan elemanları alıyoruz
            int[] dizi = new int[boyut];
            for (int i = 0; i < boyut; i++)
            {
                Console.WriteLine("Dizinin {0}. elemanını giriniz:",(i + 1));
                dizi[i] = int.Parse(Console.ReadLine());
            }

            
            Console.WriteLine("Dizinin tersten yazılışı:");
            for (int i = dizi.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(dizi[i]);
            }


        }
    }
}
