namespace Odev14_20DiziSiralama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 14. 20 elemanlı bir diziye rastgele sayılar atayın ve bu sayıları sıralayan program yazın

            int[] lists = new int[20];
            Random random = new Random();

            for (int i = 0; i < lists.Length; i++) { 

                lists[i] = random.Next(1,101);
                
            
            }

            foreach (int i in lists) {

                Console.Write(i + " ");
            
            }
            Array.Sort(lists);

            Console.WriteLine("\n\nSıralanmış Sayılar \n");

            foreach (int i in lists)
            {

                Console.Write(i + " ");

            }
            Console.WriteLine();


        }
    }
}
