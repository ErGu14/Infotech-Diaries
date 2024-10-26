namespace Odev44_Matris0degistirici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //44. Bir matristeki tüm sıfırları farklı bir sayıyla değiştiren program yazın.


            // Matrisin boyutlarını belirle
            Console.Write("Matrisin satır sayısını giriniz: ");
            int satir = int.Parse(Console.ReadLine());

            Console.Write("Matrisin sütun sayısını giriniz: ");
            int sutun = int.Parse(Console.ReadLine());

            // Matrisi oluştur
            int[,] matris = new int[satir, sutun];

            // Matris elemanlarını kullanıcıdan al
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    Console.Write($"Matrisin [{i},{j}] elemanını giriniz: ");
                    matris[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // Değiştirilecek sayıyı al
            Console.Write("Sıfırları hangi sayıyla değiştirmek istersiniz? ");
            int yeniSayi = int.Parse(Console.ReadLine());

            // Matris elemanlarını kontrol et ve sıfırları değiştir
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    if (matris[i, j] == 0)
                    {
                        matris[i, j] = yeniSayi;
                    }
                }
            }
            // Sonucu ekrana yazdır
        Console.WriteLine("Güncellenmiş matris:");
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    Console.Write(matris[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
