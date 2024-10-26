namespace Odev39_Negatif0Çevir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //39. Girilen bir dizideki negatif sayıları sıfıra çeviren program yazın.

            Console.Write("Dizinin boyutunu giriniz: ");
            int boyut = int.Parse(Console.ReadLine());

            
            int[] dizi = new int[boyut];

           
            for (int i = 0; i < boyut; i++)
            {
                Console.Write($"Dizinin {i + 1}. elemanını giriniz: ");
                dizi[i] = int.Parse(Console.ReadLine());
            }

           
            for (int i = 0; i < boyut; i++)
            {
                if (dizi[i] < 0)
                {
                    dizi[i] = 0;
                }
            }

           
            Console.WriteLine("Negatif sayılar sıfıra çevrildikten sonra dizi:");
            foreach (int eleman in dizi)
            {
                Console.Write(eleman + " ");
            }
        }
    }
}
