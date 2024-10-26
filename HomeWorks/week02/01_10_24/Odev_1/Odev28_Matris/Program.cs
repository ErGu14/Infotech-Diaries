namespace Odev28_Matris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  28. Bir matrisin transpozunu alan programı yazın.

            Console.WriteLine("Matrisin satır sayısını giriniz:");
            int satir = int.Parse(Console.ReadLine());
            Console.WriteLine("Matrisin sütun sayısını giriniz:");
            int sutun = int.Parse(Console.ReadLine());

            
            int[,] matris = new int[satir, sutun];
            Console.WriteLine("Matrisin elemanlarını giriniz:");
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    Console.Write($"Matris[{i},{j}] = ");
                    matris[i, j] = int.Parse(Console.ReadLine());
                }
            }

           
            int[,] transpoz = new int[sutun, satir];
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    transpoz[j, i] = matris[i, j];
                }
            }
            Console.WriteLine("Matrisin transpozu:");
            for (int i = 0; i < sutun; i++)
            {
                for (int j = 0; j < satir; j++)
                {
                    Console.Write(transpoz[i, j] + "\t");
                }
                Console.WriteLine();
            }
    }
}
}
