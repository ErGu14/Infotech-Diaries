namespace Odev30_Polindrom
{
    internal class Program
    {

        static bool PalindromMu(string cumle)
        {
            
            string temizCumle = new string(cumle.Where(char.IsLetterOrDigit).ToArray()).ToLower();

            
            string tersCumle = new string(temizCumle.Reverse().ToArray());

            
            return temizCumle == tersCumle;
        }

        static void Main(string[] args)
        {
            // 30. Girilen bir cümlenin palindrom olup olmadığını kontrol eden program yazın.

            Console.Write("Bir cümle giriniz: ");
            string cumle = Console.ReadLine();

            if (PalindromMu(cumle))
            {
                Console.WriteLine("Girdiğiniz cümle bir palindromdur.");
            }
            else
            {
                Console.WriteLine("Girdiğiniz cümle bir palindrom değildir.");
            }
        }
    }
}
