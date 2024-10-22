using System.Collections.Concurrent;

namespace Lesson08_KosulluYapilar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // programlarımızda duruma göre farklı akışlardan devam edilmesini sağlayan yapılardır.

            /* Console.Write("Sayı girin : ");
             int num1 = int.Parse(Console.ReadLine());

             if (num1 > 0)
             {
                 Console.WriteLine($"girdiği sayı : {num1} ve pozitiftir");

             } else if (num1 == 0){

                 Console.WriteLine("sayınız 0 ile eşit");

             }
             else {
                 Console.WriteLine($"sayınız negatif : {num1} ");
             }*/

            /*string cUserName = "eray";
            string cUserPass = "123";

            Console.Write("Kulanıcı Adı: ");
            string userName = Console.ReadLine();
            Console.Write("şifre: ");
            string userPass = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();

            if (userName == cUserName && userPass == cUserPass) {
                Console.WriteLine($"Hoşgeldiniz {userName}");
                
            }else if (userName != cUserName && userPass == cUserPass)
            {
                Console.WriteLine("Kullanıcı adınız hatalı");

            }else if(userPass != cUserPass && userName == cUserName)
            {
                Console.WriteLine("şifreniz hatalı");
            }

            else
            {
                Console.WriteLine("Kullanıcı Adı ve Şifreniz Hatalı");

            }
            Console.WriteLine();
            Console.WriteLine();
*/

            /*
                        DateTime date = new DateTime(2024,6,30);
                        int month = date.Month;
                        string message;

                        if (month == 12 || month == 1 || month == 2)
                        {
                            message = "kış";
                        }else if (month>=3 && month < 5)
                        {
                            message = "ilkbahar";
                        }else if (month>=6 && month <= 8) {
                            message = "yaz";

                        }else
                        {
                            message = "sonbahar";

                        }

                        Console.WriteLine($"{date} tarihi {message} mevsimine aittir. ");*/



            /*DateTime date = new DateTime(2024, 6, 30);
            int month = date.Month;
            string message;

            switch(month) {
                case 12:
                case 1:
                case 2:
                    message = "kış";
                    break;

                case 3:
                case 4:
                case 5:
                    message = "ilkbahar";
                    break;

                case 6: 
                case 7:
                case 8:
                    message = "yaz";
                    break;

                default:
                    message = "sonbahar";
                    break;
            }

            Console.WriteLine(message);*/


            //ternary if
            /* Console.Write("yaşınızı girin : ");
             byte age = byte.Parse(Console.ReadLine());
             string message = age >= 18 ? "girebilirsiniz" : "giriş yapamazsın";
             *//* if(age > 18)
              {
                  message = "giriniz";
              }
              else
              {
                  message = "giriş yasak";
              }*//*
             Console.WriteLine(message);*/

            /*Console.Write("yaşınızı girin : ");
            byte age = byte.Parse(Console.ReadLine());
            Console.WriteLine(age >= 18?"giriş yapabilirsin":"giriş yapamazsın");*/

            // not sistemi
            /*  0 - 45 = E
               46 - 60 = D
               61-70 = C
               71 - 85 = B
               86 - 100 = A
            */

            Console.Write("notunuzu giriniz : ");
            byte puan = byte.Parse(Console.ReadLine());

            char result = puan <= 45 ? 'E' :
                          puan <= 60 ? 'D' :
                          puan <= 70 ? 'C' :
                          puan <= 85 ? 'B' : 'A';

            Console.WriteLine($"Sayısal değer Notunuz : {puan}\nHarf olarak notunuz : {result}");

            //egzersiz : Bu örneği Switch ve if ile yapınız 




        }
    }
}
