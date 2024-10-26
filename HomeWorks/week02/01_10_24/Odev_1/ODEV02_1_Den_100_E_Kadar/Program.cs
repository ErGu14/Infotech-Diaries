namespace ODEV02_1_Den_100_E_Kadar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  2. 1'den 100'e kadar olan çift sayıları yazdıran bir program yazın.

            
            for (int i = 1; i < 101; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                

            }
        }
    }
}
