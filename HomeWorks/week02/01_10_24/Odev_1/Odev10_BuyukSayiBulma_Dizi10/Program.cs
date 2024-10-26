using System.Threading.Channels;

namespace Odev10_BuyukSayiBulma_Dizi10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 10. 10 elemanlı bir dizi tanımlayın ve bu dizideki en büyük sayıyı bulan programı yazın.

            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int buyukInt = ints[0];

            for (int i = 1; i < ints.Length; i++)
            {
                if (ints[i] > buyukInt)
                {
                    buyukInt = ints[i];
                }
            }
            Console.WriteLine(buyukInt);
        }
    }
}