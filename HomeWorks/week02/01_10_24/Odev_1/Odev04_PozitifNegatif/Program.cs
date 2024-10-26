namespace Odev04_PozitifNegatif
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcının girdiği bir sayının pozitif mi negatif mi olduğunu belirleyen program yazın. // Derse öğrenmediğim bir şeyi denedim.

            Console.Write("Hoşgeldin Bir Sayı Gir Ve Pozitif Mi Yoksa Negatif Mi Olduğunu Öğrenelim. : ");
            string input = Console.ReadLine();
            int a;

            if (int.TryParse(input, out a)) { 


                if (a > 0)
            {

                Console.WriteLine($"{a} Sayısı Pozitif");


            }
            else if (a < 0)
            {

                Console.WriteLine($"{a} Sayısı Negatif");


            }
            else 
            {

                Console.WriteLine("Bu Sayı Ne Pozitiftir Ne Negatiftir");

            }
            



            }else{

                Console.WriteLine("Yanlış Tuşlama Yaptınız Tekrar Deneyin");


            }


        }
    }
}
