namespace Odev07_Class_StoreAndProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mağaza nesnesi oluşturma
            Magaza magaza = new Magaza();

            // Ürün nesneleri oluşturma ve ekleme
            Urun urun1 = new Urun("Laptop", 15000, 10);
            Urun urun2 = new Urun("Telefon", 8000, 20);
            magaza.UrunEkle(urun1);
            magaza.UrunEkle(urun2);

            // Stoktaki ürünleri listeleme
            magaza.StoktakiUrunleriListele();

            // Ürün satma ve stok güncelleme
            magaza.UrunSat("Laptop", 2);
            magaza.StoktakiUrunleriListele();
        }
    }
}
