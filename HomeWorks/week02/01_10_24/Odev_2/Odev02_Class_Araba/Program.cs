namespace Odev02_Class_Araba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Araba araba = new Araba("Toyota", 2024);

            // Araba bilgilerini ekrana yazdırma
            araba.YakitKontrol();
            araba.Sur(50);
            araba.Sur(500);
            
        }
    }
}
