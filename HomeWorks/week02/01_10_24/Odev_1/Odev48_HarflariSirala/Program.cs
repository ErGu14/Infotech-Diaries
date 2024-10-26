namespace Odev48_HarflariSirala
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //48. Girilen bir cümledeki tüm harfleri büyükten küçüğe sıralayan program yazın.

            Console.Write("Bir cümle giriniz: ");
            string cumle = Console.ReadLine();

            // Sadece harfleri al ve büyük harfe çevir
            string sadeceHarfler = new string(cumle.Where(char.IsLetter).ToArray()).ToUpper();

            // Harfleri büyükten küçüğe sırala
            string siraliHarfler = new string(sadeceHarfler.OrderByDescending(c => c).ToArray());

            Console.WriteLine($"Cümledeki harflerin büyükten küçüğe sıralanmış hali: {siraliHarfler}");
        }
    }
}
