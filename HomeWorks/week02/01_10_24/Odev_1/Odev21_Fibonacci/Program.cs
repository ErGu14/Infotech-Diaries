namespace Odev21_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 21. Fibonacci serisini 20. terime kadar yazdıran programı yazın.

            int n = 20;  
            int a = 0, b = 1;  // Fibonacci serisinin ilk iki terimi

            Console.WriteLine("Fibonacci Serisi:");
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(a);
                int fib = a;
                a = b;
                b = fib + a;
            }
        }
    }
}
