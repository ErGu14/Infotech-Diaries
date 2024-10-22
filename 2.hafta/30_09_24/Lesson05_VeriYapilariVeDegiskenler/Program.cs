using System.Collections.Concurrent;

namespace Lesson05_VeriYapilariVeDegiskenler
{
    internal class Program
    {
        static void Main(string[] args)
        {
           /* // Ondalıklı Sayılar
            float num1 = 14.9f;
            double num2 = 30.5;
            decimal num3 = 56.89M;
            Console.WriteLine($"num1 bellek alanı : {sizeof(float)}");
            Console.WriteLine($"num 2 bellek alanı: {sizeof(double)} ");
            Console.WriteLine($"num 3 bellek alanı: {sizeof(decimal)} ");*/

            // metinsel veri tipleri 
            char karakter1 = 'A';
            char karakter2 = '%';

            string adSoyad = "Ricardo Quaresma";
            Console.WriteLine(adSoyad);
            Console.WriteLine(adSoyad[0]);

            char karakter3 = adSoyad[0];

            //Mantıksal Veri 

            bool isActive = true;
            bool isDeleted = false;

            const int a = 45;
            const int b = 50;  //değiştirilemez
            
            Console.WriteLine($"a : {a}");
            Console.WriteLine($"b : {b}");
            Console.WriteLine("*************************************");

            /*a = a + 8;
            b = b + 9;*/
            int c = a+b;
            c = a + b;

            Console.WriteLine($"a : {a}");
            Console.WriteLine($"b : {b}");
            Console.WriteLine($"a + b = {c}");



        }
    }
}
