namespace Lesson19_Kapsülleme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Category category = new Category("Çekoslavakya");
            
            Console.WriteLine(category.NameLength);
            Console.WriteLine(category.Name);
            // adı kategori 1 olan yeni bir katgori nesnesi tanımlayın
            // kategori 1 nesnesinin Name : Telefon olsun.
            // Id : 5 , Description: "Telefon kategorisi" olsun ve bu bilgiler nesne oluştururken verilsin
            Category category1 = new Category("Telefon") { 
                Id = 5,
                Description = "Telefon Kategorisi",
            };

        }
    }
}
