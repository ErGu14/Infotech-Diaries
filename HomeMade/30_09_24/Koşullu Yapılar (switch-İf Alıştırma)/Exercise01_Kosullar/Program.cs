namespace Exercise01_Kosullar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("notunuzu giriniz : ");
            byte puan = byte.Parse(Console.ReadLine());
            char result;
/*
            char result = puan <= 45 ? 'E' :
                          puan <= 60 ? 'D' :
                          puan <= 70 ? 'C' :
                          puan <= 85 ? 'B' : 'A';

            Console.WriteLine($"Sayısal değer Notunuz : {puan}\nHarf olarak notunuz : {result}");*/

            //egzersiz : Bu örneği Switch ve if ile yapınız


            //switch case

           /* switch (puan)
            {
                case <= 45:
                    result = 'E';
                    break;

                case <= 60:
                    result = 'D';
                    break;

                case <= 70:
                    result = 'C';
                    break;

                case <= 85:
                    result = 'B';
                    break;

                default:
                    result = 'A';
                    break;
            }*/

            // Console.WriteLine($"\nSayısal değer Notunuz : {puan}\nHarf olarak notunuz : {result}");

            //***************************************************************************************************

            //if else

            if (puan <= 45)
            {
                result = 'E';
            }
            else if (puan <= 60)
            {
                result = 'D';
            }
            else if (puan <= 70)
            {
                result = 'C';
            }
            else if (puan <= 85)
            {
                result = 'B';
            }
            else
            {
                result = 'A';
            }
            Console.WriteLine($"\nSayısal değer Notunuz : {puan}\nHarf olarak notunuz : {result}");


        }
        }
    }

