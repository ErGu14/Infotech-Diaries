using System.Net;

namespace Lesson13_Siniflar
{

    class House
    {
       public string streetName;
       public int doorNum;
    }

    class User
    {
        public int id;
        public string name;
        public string lastName;
        public string email;
        public string password;
        public string userName;
    }

    /* class Product // sınıf içi değikenlerin sabit değeri private dır.
     {
      private int id;
      private string name;
      private decimal price;

         public void SetPrice(decimal price)
         {
             this.price = price;
         }
         public decimal GetPrice()
         {
             if(price < 0)
             {
                 price = 0;
             }
             else
             {
                 return this.price;
             }

         }

     }*/

    class Product
    {
        int id;
        public int Id {
            get {

                return id;
            
            
            }
            set
            {
                id = value;
            }
        }

        //propfull (kısa bir şekilde get set oluşturma)

        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value > 0 ? value : 0; }
        }
        // prop ile daha kısa şekilde yazabilirsin.
        public string name { get; set; }
        public int  GetNameLenght { get { return name.Length; } }



    }

    internal class Program
    {
        static void Main(string[] args)
        {

            #region OOP Deneme region
            //Nesne Yönelimli Programlama-Object Oriente Programing(OOP)
            // Sınıflar nesnelerin kalıpları şablonlarıdır ne gibi özelliklere sahip olduğunu belirler dolayısıyla nesneler sınıflardan yaratılır bu bağlamda c# için herşey nesnedir.
            /*int num;
            num = 53;
            House house1;
            house1 = new House();

            house1.streetName = "Cennet Mahallesi";
            house1.doorNum = num;

            Console.WriteLine(house1.streetName);
            Console.WriteLine(house1.doorNum);*/
            #endregion

            #region örnek 1

            /*User user1 = new User();

            user1.id = 1;
            user1.name = "Eray";
            user1.lastName = "Bey";
            user1.email = "asadf@gmail.com";
            user1.password = "123";
            user1.userName = "xKralTrx";

            User user2 = new User()
            {
                id = 2,
                name = "Kemal",
                lastName = "Burhan",
                email = "sfjwef@gmail.com",
                password = "456",
                userName = "holl00"

            };

            User user3 = new()
            {
                id = 3,
        };*/




            #endregion


            #region örnek 2
            /*
                        Product product1 = new Product();
                        product1.SetPrice(150);
                        Console.WriteLine(product1.GetPrice());

                        Product product2 = new Product();
                        product2.SetPrice(600);
                        Console.WriteLine(product2.GetPrice());

                        Product product3 = new Product();
                        product3.SetPrice(-900);
                        Console.WriteLine(product3.GetPrice());*/




            #endregion

            #region örnek3
            Product product1 = new Product();
            product1.Price = 100;
            product1.name = "Test";
            Console.WriteLine(product1.GetNameLenght);
            #endregion
        }
    }
}
