namespace Odev08_FaktoriyelHesaplama
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //8.Kullanıcının girdiği bir sayının faktöriyelini hesaplayan bir program yazın.

            Console.Write("Bir sayı giriniz: ");
            int sayi = int.Parse(Console.ReadLine());
            long faktoriyel = 1;

            for (int i = 1; i <= sayi; i++)
            {

                faktoriyel *= i;
            }
            Console.WriteLine(faktoriyel);
        }
    }
}
