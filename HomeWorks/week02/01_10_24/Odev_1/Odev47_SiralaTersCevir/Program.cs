namespace Odev47_SiralaTersCevir
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            // Diziyi küçükten büyüğe sırala
            Array.Sort(dizi);

            // Diziyi tersine çevir
            Array.Reverse(dizi);

            // Sıralanmış ve ters çevrilmiş diziyi ekrana yazdır
            Console.WriteLine("Dizinin sıralanmış ve ters çevrilmiş hali:");
            foreach (int eleman in dizi)
            {
                Console.Write(eleman + " ");
            }
        }
    }
}
