using System.Globalization;

namespace Odev49_IlkKelimeBuyuk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 49. Kullanıcının girdiği bir cümledeki her kelimenin ilk harfini büyük harf yapan program yazın.

            Console.Write("Bir cümle giriniz: ");
            string cumle = Console.ReadLine();

            // Cümledeki her kelimenin ilk harfini büyük harf yap
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string sonuc = textInfo.ToTitleCase(cumle.ToLower());

            Console.WriteLine($"Her kelimenin ilk harfi büyük: {sonuc}");
        }
    }
}
