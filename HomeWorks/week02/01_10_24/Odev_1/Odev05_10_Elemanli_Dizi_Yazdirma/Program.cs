namespace Odev05_10_Elemanli_Dizi_Yazdirma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  5. 10 elemanlı bir dizi tanımlayın ve elemanlarını ekrana yazdırın.

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            for (int i = 0; i < numbers.Length; i++) {

                Console.WriteLine($"{i+1}. Sayı : {numbers[i]}");
            
            }
        }
    }
}
