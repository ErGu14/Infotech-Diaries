namespace Odev20_EBOB
{
    internal class Program
    {


        static int EBOB(int a, int b)
        {
            while (b != 0)
            {
                int num = b; 
                b = a % b;
                a = num;
            }
            return a;
        }



        static void Main(string[] args)
        {

            // 20. Kullanıcının girdiği iki sayının en büyük ortak bölenini (EBOB) bulan programı yazın.

            Console.Write("Birinci sayıyı girin: ");
            int sayi1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("İkinci sayıyı girin: ");
            int sayi2 = Convert.ToInt32(Console.ReadLine());

            
            int ebob = EBOB(sayi1, sayi2);

            
            Console.WriteLine("En büyük ortak bölen (EBOB): " + ebob);


        }
    }
}
