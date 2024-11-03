namespace W3S_26_09_24
{
    internal class Program
     {
        //farklı bir static çağırarak  matematiksel bir işlem yapalım

        static int myFirstMethod(int x, int y,int o) {  
            return x + y + o;
        }

        static void Main(string[] args)
        {
            /*// Bu derste c# methodlarını öğreniyorum.
             Bu metodlar sayesinde ayrı bir static oluşturarak sayı ve string döndürebiliyoruz. W3school üzerinden ilerliyorum ordan egzersizlerle
            beraber bilgilerimi tazeliyorum burada sadece biraz farklı denme yapıyorum.


             */

            int z = myFirstMethod(1,2,3);
            Console.WriteLine(z);


        }
    }
}
