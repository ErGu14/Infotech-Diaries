using System.Xml;

namespace Lesson17_Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* GenderType gender;
             gender = GenderType.Male;
             Console.WriteLine(gender);
             gender = GenderType.Female;
             Console.WriteLine(gender);

             if ((int)gender == 1) {
                 Console.WriteLine("Selamlar");
             }

             if (gender == GenderType.Female) {
                 Console.WriteLine("selamlar");
             }*/

            OrderState orderState = OrderState.KargoyaVerildi;
            //Siparişiniz kargoya verildi

            /* if ((int)orderState == 0)
             {
                 Console.WriteLine("Siparişiniz Hazırlanıyor");

             }
             else if ((int)orderState == 1)
             {
                 Console.WriteLine("Siparişiniz Hazırlanıyor");
             }
             else if ((int)orderState == 2)
             {
                 Console.WriteLine("Siparişiniz Kargoya Verildi");
             }
             else {
                 Console.WriteLine("Siparişiniz Teslim Edildi");
             }*/

            int orderStateInt = (int)OrderState;

            switch (orderStateInt)
            {
                case 0;
                    Console.WriteLine("Sipariş Alındı");
            }
        }
    }
}
