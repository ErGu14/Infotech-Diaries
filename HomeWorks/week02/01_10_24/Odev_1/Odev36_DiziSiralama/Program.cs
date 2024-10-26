namespace Odev36_DiziSiralama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 36. Kullanıcının girdiği bir diziyi küçükten büyüğe sıralayan program yazın.

            Console.Write("Dizinin boyutunu giriniz: ");
            int boyut = int.Parse(Console.ReadLine());

           
            int[] dizi = new int[boyut];

           
            for (int i = 0; i < boyut; i++)
            {
                Console.Write($"Dizinin {i + 1}. elemanını giriniz: ");
                dizi[i] = int.Parse(Console.ReadLine());
            }

            
            Array.Sort(dizi);

            
            Console.WriteLine("Dizinin küçükten büyüğe sıralanmış hali:");
            foreach (int eleman in dizi)
            {
                Console.Write(eleman + " ");
            }

        }
    }
}
