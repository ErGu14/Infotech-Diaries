namespace Odev34_KelimeTersCevirici
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //34. Girilen bir cümlenin tüm kelimelerini ters çeviren program yazın.

            Console.Write("Bir cümle giriniz: ");
            string cumle = Console.ReadLine();

            
            string[] kelimeler = cumle.Split(' ');

            
            for (int i = 0; i < kelimeler.Length; i++)
            {
                char[] kelimeArray = kelimeler[i].ToCharArray();
                Array.Reverse(kelimeArray);
                kelimeler[i] = new string(kelimeArray);
            }

           
            string tersCumle = string.Join(" ", kelimeler);

            Console.WriteLine($"Ters çevrilmiş cümle: {tersCumle}");
        }
    }
}
