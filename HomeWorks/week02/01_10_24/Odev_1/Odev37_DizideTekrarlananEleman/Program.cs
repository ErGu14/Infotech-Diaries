namespace Odev37_DizideTekrarlananEleman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //37. Bir dizide tekrarlanan elemanları bulan program yazın.

            Console.Write("Dizinin boyutunu giriniz: ");
            int boyut = int.Parse(Console.ReadLine());

            
            int[] dizi = new int[boyut];

            
            for (int i = 0; i < boyut; i++)
            {
                Console.Write($"Dizinin {i + 1}. elemanını giriniz: ");
                dizi[i] = int.Parse(Console.ReadLine());
            }

            
            var tekrarlananlar = dizi.GroupBy(x => x)
                                     .Where(g => g.Count() > 1)
                                     .Select(y => y.Key)
                                     .ToList();

            
            if (tekrarlananlar.Count > 0)
            {
                Console.WriteLine("Tekrarlanan elemanlar: " + string.Join(", ", tekrarlananlar));
            }
            else
            {
                Console.WriteLine("Dizide tekrarlanan eleman yok.");
            }
        }
    }
}
