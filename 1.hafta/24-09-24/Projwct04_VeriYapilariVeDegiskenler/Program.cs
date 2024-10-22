namespace Projwct04_VeriYapilariVeDegiskenler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //değişkenler;
/*
            int age = 18;
            string name;
            name = "Eray";
            string ageOfEray = "20";*/

            //camelCase 
            //studentNumber
            //firstName
            //last_name

            //veri tipleri
            // 1- sayısal tipler
            sbyte student1 = 99;
            byte student2 = 56;
            short orderCount = 300; //eksi bile yazabilirsin
            ushort orderCount2 = 99; //unaigned yani (-) alamaz
            int totalLastYear = 1000;
            uint totalLastYear2 = 1000; //eksi alamaz

            long count = 99999999999999999;
            ulong count2 = 99;


            /*Console.Write("shortun maks değeri: ");
            Console.WriteLine(short.MaxValue);
            Console.Write("shortun min değeri: ");
            Console.WriteLine(short.MinValue);
            Console.Write("shortun byte türü değeri");
            Console.WriteLine(sizeof(short));
            Console.Write("shortun bit türü değeri");
            Console.WriteLine(sizeof(short) * 8);*/
            /*
                        Console.WriteLine("short maks: "+ short.MaxValue);
                        Console.WriteLine("short min: " + short.MinValue);
                        Console.WriteLine("short size: " + sizeof(short)+ " byte");*/

            string name = "Eray";
            string lastName = "Bey";
            Console.WriteLine(name + " " + lastName);

            Console.WriteLine($"sayın {name} {lastName}");




        }
    }
}
