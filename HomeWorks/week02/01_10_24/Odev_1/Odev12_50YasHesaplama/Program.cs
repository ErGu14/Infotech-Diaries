namespace Odev12_50YasHesaplama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 12. Kullanıcının yaşını girip kaç yıl sonra 50 yaşına geleceğini hesaplayan programı yazın.

            Console.Write("Yaaşınızı Giriniz : ");
            int yas = int.Parse(Console.ReadLine());
            
             if (yas < 50){

                Console.WriteLine($"50 Yaşına gelmenize {50 - yas} yıl var.");


             }
            else
            {
                Console.WriteLine($"Siz  {yas - 50} yıl önce zaten 50 yaşındaydınız. ");
            }


        }
    }
}
