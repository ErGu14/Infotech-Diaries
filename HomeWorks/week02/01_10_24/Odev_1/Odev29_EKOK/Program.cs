namespace Odev29_EKOK
{
    internal class Program
    {

        static int Ebob(int sayi1, int sayi2)
        {
            while (sayi2 != 0)
            {
                int temp = sayi2;
                sayi2 = sayi1 % sayi2;
                sayi1 = temp;
            }
            return sayi1;
        }

        
        static int Ekok(int sayi1, int sayi2)
        {
            return (sayi1 * sayi2) / Ebob(sayi1, sayi2);
        }


        static void Main(string[] args)
        {
            //29. Kullanıcının girdiği iki sayının en küçük ortak katını (EKOK) bulan programı yazın.

            Console.Write("Birinci sayıyı giriniz: ");
            int sayi1 = int.Parse(Console.ReadLine());

            Console.Write("İkinci sayıyı giriniz: ");
            int sayi2 = int.Parse(Console.ReadLine());

            int ekok = Ekok(sayi1, sayi2);

            Console.WriteLine($"{sayi1} ve {sayi2} sayılarının EKOK'u: {ekok}");
        }
    }
}
