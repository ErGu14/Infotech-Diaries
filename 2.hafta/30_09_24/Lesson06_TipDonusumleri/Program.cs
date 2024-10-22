using System.Dynamic;

namespace Lesson06_TipDonusumleri
{
    internal class Program
    {
        static void Main(string[] args)
        {
           /* byte a = 55; //int to byte implicit converting(casting)
            //byte b = 256; //int to byte yapamıyor

            int c = 50000000;
            long d = c;

            //explicit converting
            double e = 256;
            int f = Convert.ToInt32(e);
            Console.WriteLine(e);
            Console.WriteLine(f);
            //byte g = Convert.ToByte(e) // bu kod run time error verir
            byte g = (byte)e;*/


            string age = "56";
            int diff = 65 - byte.Parse(age);
            int diff2 = 65 - Convert.ToByte(diff);

            string size = "173";
            int sizeInt = int.Parse(size);

            Console.WriteLine(size + 3);
            Console.WriteLine(sizeInt + 3);






        }
    }
}
