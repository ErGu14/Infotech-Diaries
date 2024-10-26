namespace Odev06_SayiKarsilastirma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //6. Kullanıcının girdiği iki sayıyı karşılaştıran ve büyük olanı ekrana yazdıran programı yazın.

            Console.WriteLine("Sayıları Karşılaştıralım.");
            Console.Write("İlk Sayınız? : ");
            string num1 = Console.ReadLine();
            int numara1;
            Console.Write("İkinci Sayınız? : ");
            string num2 = (Console.ReadLine());
            int numara2;

            if (int.TryParse(num1, out numara1) && int.TryParse(num2, out numara2))
            {

                if (numara1 > numara2)
                {
                    Console.WriteLine($"{numara1},{numara2} sayısından büyüktür.");
                }
                else if (numara1 < numara2)
                {

                    Console.WriteLine($"{numara2},{numara1} sayısından büyüktür.");

                }
                else
                {

                    Console.WriteLine($"Bu İki Sayı Birbirine Eşittir.");


                }
            }
            else {


                Console.WriteLine("Eksik Veya Hatalı Tuşlama Yaptınız Tekrar Deneyiniz");
                
            }
        }
    }
}
