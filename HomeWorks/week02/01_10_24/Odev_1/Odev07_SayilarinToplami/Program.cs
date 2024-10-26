namespace Odev07_SayilarinToplami
{
    internal class Program
    {
        // 7.Kullanıcıdan alınan iki sayıyı toplayan bir program yazın.

        static int Sum(int num1, int num2) { 
            return num1 + num2;
        
        }
        static void Main(string[] args)
        {
            Console.WriteLine("*****Toplama İşlemi******\n\n");
            Console.Write("İlk Sayıyı Giriniz : ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("İkinci Sayıyı Giriniz : ");
            int b = int.Parse(Console.ReadLine());

            int sonuc = Sum(a, b);

            Console.WriteLine($"İşlem Sonucu : {sonuc}");
        }
    }
}
