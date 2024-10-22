using Lesson14_SiniflarMetodlar.Members;
using Lesson14_SiniflarMetodlar.Shoping;

namespace Lesson14_SiniflarMetodlar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product();
            Role role1 = new Role
            {
                Id = 1,
                Name = "admin",
                Description = "Selam",


            };
            role1.DisplayInfo();


        }
    }
}
