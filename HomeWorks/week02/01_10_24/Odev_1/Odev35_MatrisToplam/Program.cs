namespace Odev35_MatrisToplam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 35. Bir matristeki tüm elemanların toplamını bulan programı yazın.

            Console.Write("Matrisin satır sayısını giriniz: ");
            int satir = int.Parse(Console.ReadLine());

            Console.Write("Matrisin sütun sayısını giriniz: ");
            int sutun = int.Parse(Console.ReadLine());

            
            int[,] matris = new int[satir, sutun];

            
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    Console.Write($"Matrisin [{i},{j}] elemanını giriniz: ");
                    matris[i, j] = int.Parse(Console.ReadLine());
                }
            }

            
            int toplam = 0;
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    toplam += matris[i, j];
                }
            }

            
            Console.WriteLine($"Matrisin tüm elemanlarının toplamı: {toplam}");
        }
    }
}
