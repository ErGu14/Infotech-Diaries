


namespace Lesson09_Metods
{
    internal class Program
    {
        // static sözcüğünü oop konularında ne anlama geldiğini öğreneceğiz.

        static int Topla() // c# da önemli geleneklerinden biri Pacal Cse tekniği ile yazılması yani ilk harfi büyük olucak.
        {
            int a = 4 + 1;
            return a;

        }

        static int Deneme(int o, int r, int n)
        {
            int sonuc = o + r + n;
            return sonuc;
        }

        static int IkiSayiyiTopla(int x,int y,int z)
        {
            int sonuc = x + y + z;
            return sonuc;
        }

        static decimal CalculateTax(decimal productPrice)
        {
            double rateOfTax = 0.2;
            decimal tax = productPrice * (decimal)rateOfTax;
            return tax;
        }


        static decimal CalculateIncludeTax(decimal productPrice, decimal rateOfTax)
        {
            return productPrice *( 1 + rateOfTax);
        }

        static string GenerateSmsCode() {
            Random rnd = new Random();
            string n1 = rnd.Next(0,10).ToString();
            string n2 = rnd.Next(0,10).ToString();
            string n3 = rnd.Next(0,10).ToString();
            string n4 = rnd.Next(0,10).ToString();
            string n5 = rnd.Next(0,10).ToString();
            string n6 = rnd.Next(0,10).ToString();
            return $"{n1}-{n2}-{n3}-{n4}-{n5}-{n6}";

        }






        static void Selam()
        {
            Console.WriteLine("Selamlar Sevgiler");
            Console.WriteLine("Çok iyisin");
            Console.WriteLine("****************");
        }

        static void Main(string[] args) // Bir .net konsol uygulaması ilk çalıştırıldığında main metodunu çalıştırır.
        {
            /*  Selam();
              int a = 50;
              double b = 40;
              string message = "laylaylay";
              Selam();

              int num = Topla();
              Console.WriteLine(num*num);*/

            /*Console.WriteLine(IkiSayiyiTopla(20, 10, 67));
            Console.WriteLine(Deneme(54,23,90));*/

            decimal price = 100;
            decimal result = price + CalculateTax(price);
            Console.WriteLine(result);

            decimal result2 = CalculateIncludeTax(price, 0.2m);
            Console.WriteLine(result2.ToString("N0"));


            Console.WriteLine(GenerateSmsCode());
        }
    }
}
