namespace Project_Homework02_AyselSinifiniTanitiyor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string myName = "Aysel"; 
            string className = "11-C";
            string classMate1 = "Selim";
            string classMate2 = "Ceren";
            string classMate3 = "Rukiye";
            string classMate4 = "Çiğdem";
            string classMate5 = "Ufuk";
            string asistantManager = "Serhan";
            string asistantManagerGender = "Bey";
            string destination1 = "Avcılar";
            string destination2 = "Maltape";

            Console.WriteLine($"Benim adım {myName}. Bizler {className} sınıfında okuyoruz. Bugün sınıfta {classMate1}, {classMate2},{classMate3},{classMate4} ve{classMate5} birlikte bir oyun oynadık. {myName}-{classMate1}, {classMate2}-{classMate4} ve {classMate3}-{classMate5} şeklinde takımlara ayrıldık. Oyunun sonunda {classMate2}-{classMate4} takımı şampiyon olurken, {myName}-{classMate1} sonuncu oldu. Sonuncu olan {myName}-{classMate1} takımı müdür yardımcısının odasına gidip, yemek istedi. Müdür yardımcısı {asistantManager} {asistantManagerGender}, bizlere kızıp bol bol nasihat etti. {classMate1}, {classMate3} ve {classMate4} {destination1} otobüsüne binerken, {classMate2} ve {classMate5} ise {destination2} otobüsüne bindi. Evlerimize dağılmış olduk.");

            // Hocam internette  bir tane metod buldum onu da kullanmak istedim.()

            Console.WriteLine("*******************");
            Console.WriteLine("Benim adım {0}. Bizler {1} sınıfında okuyoruz. Bugün sınıfta {2}, {3},{4},{5} ve{6} birlikte bir oyun oynadık. {0}-{2}, {3}-{5} ve {4}-{6} " +
                "şeklinde takımlara ayrıldık. Oyunun sonunda {3}-{5} takımı şampiyon olurken, {0}-{2} sonuncu oldu. Sonuncu olan {0}-{2} takımı müdür yardımcısının odasına gidip, yemek istedi. " +
                "Müdür yardımcısı {7} {8}, bizlere kızıp bol bol nasihat etti. " +
                "{2}, {4} ve {5} {9} otobüsüne binerken, {3} ve {6} ise {10} otobüsüne bindi. Evlerimize dağılmış olduk.",myName,className,classMate1,classMate2,classMate3,classMate4,classMate5,asistantManager,asistantManagerGender,destination1,destination2);

        }
    }
}
