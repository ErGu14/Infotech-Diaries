using System.Collections.Concurrent;

namespace Lesson12_Döngüler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // for : dönüş(sayısı) belirli veya belirlenebilir ise tercih edilmesi gereken döngüdür.

            /* for (int i = 0; i < 10; i++) //for döngüsü 3 bölümden oluşur.
             {                            // int i = 0  :  döngü değişkeni tanımlanıyor.
                                          // i < 10  :  döngünün dönmeye devam etme kouşulu.
                                          //i++ : döngü her döndüğünde i yi 1 arttır.

             }*/

            /* for (int i = 0; i < 5; i++)
             {

                 Console.WriteLine($"Selam {i+1}");

             }*/

            // 1 -kullanıcının 5 değer girmesi ve o sayıların toplanması

            /*int sum = 0;
            int num1;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i+1}.Sayıyı girin");
                num1 = int.Parse (Console.ReadLine());
                sum += num1;
            }
            Console.WriteLine(sum);*/

            // 2- while :  bir koşula bağlı olarak çalışır koşul doğru olduğu sürece sonsuza kadar devam eder.
            /*
                        int i = 0;


                        while (i < 5) {

                            Console.WriteLine("selamlar");
                            i++;


                        }*/

            /*string currentPass = "1903";
            string pass = "";

            while (currentPass != pass)
            {
                Console.Write("şifren?");
                pass = Console.ReadLine();
            }*/

            //3- Do While = en az 1 kez çalışır çünkü koşul döngü sonunda kontrol edilir.

            /*
                        string currentPass = "1903";
                        string pass;

                        do
                        {
                            Console.Write("şifren?");
                            pass = Console.ReadLine();
                        } while (pass != currentPass);
                        Console.WriteLine("giriş yaptın");*/

            //4- foreach : koleksiyonlar içinde döngü kurabilmek için kullanılır şimdilik bildiğiniz sadece diziler var.

            /*string[] studentNames = { "ayşe ", "fatma", "hayriye", "nuri", "Serkan" };*/

            /* for(int i=0; i < studentNames.Length; i++) {
                 Console.WriteLine(studentNames[i]);
             }*/

            // while ile yazma

            /*int i= 0;

            while (i < studentNames.Length)
            {
                Console.WriteLine(studentNames[i]);
                i++;
            }*/

            /* foreach (string i in studentNames)
             {
                 Console.WriteLine(i);
             }*/

            /*for (int i = 0; i < studentNames.Length; i++)
            {
                studentNames[i] += " Gün";
            }*/

            string[] uruns = { "iphone 16","samsung s24","macbook air" };
            int[] fiyats = { 120000, 50000, 60000 };

            // fikir =  iphone 16 = fiyat  (örnek )

            for (int i = 0; i < uruns.Length; i++)
            {
                Console.WriteLine($"{uruns[i]}----{fiyats[i]}");
            }



        }
    }
}
