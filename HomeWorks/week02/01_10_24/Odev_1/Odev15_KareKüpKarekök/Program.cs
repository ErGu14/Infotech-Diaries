namespace Odev15_KareKüpKarekök
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //15. Kullanıcının girdiği sayının karesini, küpünü ve karekökünü hesaplayan program yazın.


            Console.Write("Sayı Giriniz : ");
            Double Sayi = Convert.ToDouble(Console.ReadLine());

            double kare = Math.Pow(Sayi,2);
            double kup = Math.Pow(Sayi,3);
            double karekok = Math.Sqrt(Sayi);

            Console.WriteLine("Sayının karesi: " + kare);
            Console.WriteLine("Sayının küpü: " + kup);
            Console.WriteLine("Sayının karekökü: " + karekok);
        }
    }
}
