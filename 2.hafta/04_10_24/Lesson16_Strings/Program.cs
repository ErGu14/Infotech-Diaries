using System;
using System.Globalization;

namespace Lesson16_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string yazi;
            yazi = "Bu bir string ifadedir";
            StringMethods();  



        }
        public static void StringIntro()
        {
            string value = "Türkiye'nin başkenti Ankara'dır.";
            Console.WriteLine(value.GetType());
            /*for (int i = 0;i < value.Length; i++)
            {
                if (i+1 < value.Length && value[i+1] == '\'')
                {
                    Console.WriteLine($"{value[i]}{value[i+1]}");
                    i++;
                }
                else
                {
                    Console.WriteLine(value[i]);
                }
            }*/
            /*int index = 0;
            foreach (var letter in value)
            {
                
                
                char nextChar = value[index];
                if (index < value.Length && value[index] == '\'')
                {
                    Console.WriteLine($"{letter}{nextChar}");
                }
                else if (letter != '\'') {
                    Console.WriteLine(letter);
                
                
            }
                index++;*/
            }
        public static void StringMethods() {

            string text = "InfoTech Academy MSCD Yazılım Eğitimine Hoş Geldiniz";
            Console.WriteLine(text.ToUpper());
            Console.WriteLine(text.ToLower());
            Console.WriteLine(text);

            var newText = text.Clone();
            Console.WriteLine($"text i harfi ile bitiyor mu? {text.EndsWith("i")}");
            Console.WriteLine($"text I harfi ile başlıyor mu? {text.StartsWith("I")}");
            Console.WriteLine($"T harfi text içerisinde kaçıncı sırada ? : {text.IndexOf("T")}");
            Console.WriteLine($"MSCD İfadesi text içerisinde kaçıncı sırada ? : {text.IndexOf("MSCD")}");
            Console.WriteLine($"tex içerisindeki en son e harfinin yeri nerede? : {text.LastIndexOf("e")}");
            Console.WriteLine(text.IndexOf("x"));

            Console.WriteLine();

            Console.WriteLine(text.Insert(9, "(Mecidiyeköy) "));
            Console.WriteLine();
            Console.WriteLine(text.Substring(0,8));
            Console.WriteLine(text.Substring(17,4));
            Console.WriteLine(text.Substring(17));

            Console.WriteLine();

            String adress = "Kemal Cadan Mah, Karanfil sk, Nida Apt., D:5, Üsküdar,İstanbul";
            Console.WriteLine();
            string[] adressArray = adress.Split(',');
            foreach (string str in adressArray) {
                Console.WriteLine(str.Trim());
            }
        }
        }
    }
