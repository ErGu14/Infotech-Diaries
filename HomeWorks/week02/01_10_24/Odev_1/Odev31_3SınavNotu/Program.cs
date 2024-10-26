namespace Odev31_3SınavNotu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //31. Bir öğrencinin aldığı üç sınav notunu ortalamasına göre sınıfı geçti mi kaldı mı belirleyen program yazın.

       
            Console.Write("Birinci sınav notunu giriniz: ");
            double not1 = double.Parse(Console.ReadLine());

            Console.Write("İkinci sınav notunu giriniz: ");
            double not2 = double.Parse(Console.ReadLine());

            Console.Write("Üçüncü sınav notunu giriniz: ");
            double not3 = double.Parse(Console.ReadLine());

         
            double ortalama = (not1 + not2 + not3) / 3;

           
            Console.WriteLine($"Not ortalamanız: {ortalama:F2}");

        
            if (ortalama >= 50)
            {
                Console.WriteLine("Tebrikler, sınıfı geçtiniz!");
            }
            else
            {
                Console.WriteLine("Maalesef, sınıfta kaldınız.");
            }
        }
    }
}
