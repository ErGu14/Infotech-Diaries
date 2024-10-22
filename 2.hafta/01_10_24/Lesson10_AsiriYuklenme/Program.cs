using System.Collections.Concurrent;

namespace Lesson10_AsiriYuklenme
{
    internal class Program
    {

        static string SmsGenerate()
        {
            Random rnd = new Random(); 
            int num1 = rnd.Next(0,10);
            int num2 = rnd.Next(0,10);
            int num3 = rnd.Next(0,10);
            int num4 = rnd.Next(0,10);  
            int num5 = rnd.Next(0,10);
            int num6 = rnd.Next(0, 10);
            string smscode = $"{num1}{num2}{num3}{num4}{num5}{num6}";
            return smscode;
        }

        static int Sum(int n1, int n2)
        {
            return n1 + n2;
        }

        static int Sum(int x1, int x2, int x3)
        {
            return x1 + x2 + x3;
        }

        static double Sum(double y1, double y2)
        {

            return y1 + y2;

        }

        static void Main(string[] args)
        {
            /*Console.WriteLine(SmsGenerate());*/

        }
    }
}
