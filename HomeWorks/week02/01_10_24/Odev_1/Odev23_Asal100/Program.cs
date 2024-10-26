namespace Odev23_Asal100
{
    internal class Program
    {

        static bool AsalMi(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            // 23. 1'den 100'e kadar olan asal sayıları bulan bir program yazın.

            Console.WriteLine("1'den 100'e kadar olan asal sayılar:");
            for (int i = 2; i <= 100; i++)
            {
                if (AsalMi(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}