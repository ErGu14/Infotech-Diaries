namespace Odev16_5ElemanliDizi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  16. 5 elemanlı bir dizi tanımlayın, kullanıcıdan bu dizinin elemanlarını girmesini isteyin ve ekrana yazdırın.

            int[] list = new int[5];

            for(int i = 0; i < list.Length; i++)
        {
                Console.Write("Dizinin {0}. elemanını girin: ", i + 1);
                list[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Dizinin elemanları:");
            foreach (int sayi in list)
            {
                Console.Write(sayi + " ");
            }
        }
    }
}
