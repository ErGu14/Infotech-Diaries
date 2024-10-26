namespace Odev50_DiziKaristici
{
    internal class Program
    {

        static void RastgeleKaristir(int[] dizi)
        {
            Random rnd = new Random();
            for (int i = dizi.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                int temp = dizi[i];
                dizi[i] = dizi[j];
                dizi[j] = temp;
            }
        }

        static void Main(string[] args)
        {
            // 50. Girilen bir diziyi rastgele karıştıran program yazın.

            // Kullanıcıdan dizi boyutunu al
            Console.Write("Dizinin boyutunu giriniz: ");
            int boyut = int.Parse(Console.ReadLine());

            // Diziyi oluştur
            int[] dizi = new int[boyut];

            // Dizinin elemanlarını kullanıcıdan al
            for (int i = 0; i < boyut; i++)
            {
                Console.Write($"Dizinin {i + 1}. elemanını giriniz: ");
                dizi[i] = int.Parse(Console.ReadLine());
            }

            // Diziyi rastgele karıştır
            RastgeleKaristir(dizi);

            // Karıştırılmış diziyi ekrana yazdır
            Console.WriteLine("Rastgele karıştırılmış dizi:");
            foreach (int eleman in dizi)
            {
                Console.Write(eleman + " ");
            }

        }
    }
}
