namespace Odev43_GirilenSayilariSirala
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //43. Kullanıcının girdiği bir dizi içerisindeki sayıları büyükten küçüğe sıralayan program yazın.
           
            Console.Write("Dizinin boyutunu giriniz: ");
            int boyut = int.Parse(Console.ReadLine());

          
            int[] dizi = new int[boyut];

          
            for (int i = 0; i < boyut; i++)
            {
                Console.Write($"Dizinin {i + 1}. elemanını giriniz: ");
                dizi[i] = int.Parse(Console.ReadLine());
            }

           
            dizi = dizi.OrderByDescending(x => x).ToArray();

            
            Console.WriteLine("Dizinin büyükten küçüğe sıralanmış hali:");
            foreach (int eleman in dizi)
            {
                Console.Write(eleman + " ");
            }
        }
    }
}
