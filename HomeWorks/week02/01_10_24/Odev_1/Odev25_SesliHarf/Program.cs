namespace Odev25_SesliHarf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //25. Kullanıcının girdiği bir cümledeki sesli harflerin sayısını bulan programı yazın.

            char[] sesliHarfler = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü', 'A', 'E', 'I', 'İ', 'O', 'Ö', 'U', 'Ü' };

            
            Console.WriteLine("Bir cümle giriniz:");
            string cumle = Console.ReadLine();

            int sesliHarfSayisi = 0;

            
            foreach (char harf in cumle)
            {
                if (Array.Exists(sesliHarfler, element => element == harf))
                {
                    sesliHarfSayisi++;
                }

            }
            Console.WriteLine("\nCümledeki sesli harf sayısı: " + sesliHarfSayisi);
        }

    }
    
}
