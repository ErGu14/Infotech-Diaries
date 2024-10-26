namespace Odev03_1_Den_100_E_TekSayiler
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1'den 100'e kadar olan tek sayıları yazdıran bir program yazın.

            int i;
            for (i = 1; i <= 101; i++) {

                if (i % 2 != 0) { 

                    Console.WriteLine(i);
                
                
                }
            
            }
        }
    }
}
