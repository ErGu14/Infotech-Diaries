namespace W3S_24_09_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*  
               Burada yazılanlar  o gün öğrenilen bilgiler
            *******************************************************************
               Data Types(Yeni öğrendiğim)

               bool = true veya false döndürmeye yarar
               char = tek bir harfi simgeler
               double = küsürlü sayılar için kullanılır (9.5 , 1.2) (ondalıklı sayılar)
               float = küsürlü sayılar için kullanılır(double ile farkı yüksek hassasiyet gerektirmemesi)  örnek : float f1 = 35e3F
             ******************************************************************************
             Constants (const) = örnek verirsek bir int değeri verdik ve bu değerin hiçbir şekilde değiştirilmemesi lazım bu veri tipi sayesinde verinin değişmesini engelleye biliriz
             örnek :
             const int num1 = 3
             num1 = 10 // error vericektir
             **********************************************************************
             Multiple Variables
              
            Birden fazla veriyi aynı satırda ve aynı türde kısa bir şekilde yazabiliyoruz (virgül ile)
            örnek:
            int x = 5, y = 6, z = 50; veya int x, y, z;
                                           x = y = z = 50;
             
             dönüştürme:

             Convert.ToInt32 = stringi Inte çevirme

            Arithmetic Operators
            + : 2 sayıyı toplama
            - : 2 sayıyı çıkarma
            * : 2 sayıyı çarpma
            / : 2 sayıyı birbirine böler
            % : sayıları böldükten sonra kalanı verir
            ++ : bir değişkenin değerini 1 arttırır
            -- : bir değişkenin değerini 1 azaltır

            Assignment Operators

            &= (Bitwise AND ve Atama): Sağdaki değeri soldaki değişkenle bit düzeyinde AND işlemi yapar ve sonucu atar. (yani her 2 bit 1 ise 1 döndürür değilse 0 döndürür)
            && = Logical AND operatörü &&, iki koşulun da doğru olması durumunda true sonucunu verir. Eğer herhangi bir koşul yanlışsa false sonucunu verir. //bool result = (5 > 3) && (8 > 6); // true
            |= (Bitwise OR ve Atama): Sağdaki değeri soldaki değişkenle bit düzeyinde OR işlemi yapar ve sonucu atar. (yani 2 bitin biri 1 ise 1 döndürür)
            ^= (Bitwise XOR ve Atama): Sağdaki değeri soldaki değişkenle bit düzeyinde XOR işlemi yapar ve sonucu atar. (yani 2 bit aynıysa 1 değilse 0 döner)
            >>= (Sağa Kaydırma ve Atama): Sağdaki değeri soldaki değişkeni bit düzeyinde sağa kaydırır ve sonucu atar. (bitleri sağa kaydıır 0 ekleme)
            <<= (Sola Kaydırma ve Atama): Sağdaki değeri soldaki değişkeni bit düzeyinde sağa kaydırır ve sonucu atar. (bitleri sola kaydırıp 0 ekleme)

            Logical Operators

            && = "ve" anlamına gelir
            || = "veya" anlamına gelir
            ! = "değilse" anlamına gelir // !(x < 5 && x < 10)

            MATH
            
            max,min
            sqrt = sayının kare kökünü alır
            Abs = sayının pozitif mutlak değerini alır
            Round = ondalık bbir sayıyı en yakın sayıya yuvarlar

            strings:

            .lenght = bir stringin uzunluğunu söyler
            .ToUpper = str nin içindeki tüm yazıalrı büyük harfe çevrir.
            .ToLower = str nin içindeki tüm yazıları küçük harfe çevirir.
            .Concat =  2 değeri string cinsinden birleştirir ((+) işareti yerine kullanılabilir)

            Access Strings

            Diyelim elimizde string cinsinden bir değer var. Bu değerin bir veya biirkaç tane elemanını almamız lazım bunun içinde [] kullanarak 
            ve içine istediğimiz karakterin index sini yazarak istenilen karaktere ulaşabiliriz.

            index = Yazılımda “index” terimi, veritabanı yönetiminde ve veri arama işlemlerinde sıkça kullanılır. Bir index, veritabanındaki verilere 
            hızlı erişim sağlamak amacıyla oluşturulan özel bir veri yapısıdır.
        
            .IndexOf() = bu komut sayesinde dizedeki belirli bir karakterin indexini yani dizin konumunu bulmamızı sağlıyor.
            .Substring() = dizenin belirli bir bölümü almak için kullanılır

            stringde eğet bir şeyi vurgulamak istersen örnek :   "Bu dünyanın "Kralı"Benim"   = burdaki 'Kralı' sözcüğünü uygulama bir değer olarak tanımlicazk ve sözcüğü ekrana yazdırmicak
            Bu yüzden \" , \' ve \\ gibi ifadeler kullanılır . Bu ifadeler metinleri birleştirmemize yarıyor. Yukardaki örneği bu kurala göre yazarsak
            
            Console.WriteLine("Bu dünyanın \"Kralı\" Benim")  = bu sayede hem "kralı" kelimesini cümlede vurgulamış olduk hemde kodu yazarken "Kralı" sözcüğünü bir değer olarak değil 
            yazı olduğunu belirttik


            Switch

            Bu yapı if else in daha kapsamlı hali yani yürütülcek birçok kod bloğundan birini seçer ve işlemi durdurur. (açıklamayı yapamadım ama mantığını anladım)
            bu yapının yanın "default" komudu da vardır bu komut eğer girilen değerler diğer olasıklarla eşleşmez ise varsayılan girdi ele alınır.



            for / foreach / while

            for : Koşullu döngü ifadesiri yani döngü için ilk bir değer gireriz sonra değerin koşulunu belirleriz örnek i <= 10 gibi son olarakta döngünün devamı için yani sonsuz bir döngü olmaması için artırılır.
            foreach : for döngüsünden farkı dışardaki değerli bir döngü içine almak yani for gibi direkt içerden bir döngü değeri oluşturmak yerinedışardaki değerleri bir döngü içine alabiliyoruz
            while : bir koşul olduğu müddetçe döngü devam eder eğer değerini değiştirmezsek veya başka bir koşul olana kadar durdurmazsak sonsuza kadar devam eder

            ARRAY yapısı yani listeleme

            bir değerin içine listeleme oluşturmak için string[] veya int[] gibi başlangıç yaptıktan sonra isimlendiririz. İsimlendirme yaptıktan sonra {} ile birlikte listede olacak elemanlar yer alır.
            listedeki 1 veya birden fazla elemanı çağırmak için =  değerİsmi[0] gibi

            new = bu komut sayesinde arrayin içine yeni elemanlar oluşturmamızı sağlar
            .sort() = bu komut bir liste içindeki elemanları alfabetik sıraya veya bir sayıysa büyükten küçüğe doğru sıralar

            tabi diğer konulardada işlediğimiz max min komutları burdada işe yarar

            max = listedeki en büyük değeri yazdırır
            min = listedeki en küçük değeri yazdırır
            sum =  listedeki sayıların toplamını yazdırır.

            not = bu yukardaki max,min ve sum komutları çoğunlukla int değerindeki listeler için kullanılır.
          







            ************************************************************************************************************
            
          
           
            
             */

            // deneme kodlar

            /*int x = 2;
            Console.WriteLine(x ^= 3);*/

            /* string Abc = "WEOEIFJWIOEWFJIJWG02393I9032I4E9PFOJ";
             Console.WriteLine(Abc.Length);*/

            /* string al = "ssssssssssssssssssssssssss";
             al = al.ToUpper();

             Console.WriteLine(al);*/

            /* // substring örnek

             string test = "Merhaba Takım";
             string test1 = test.Substring(0, 7);
             string test2 = test.Substring(7);

             Console.WriteLine("testin sadece MERHABA kısmını alır = " + test1);
             Console.WriteLine("testin sadece TAKIM kısmını alır = " + test2);

            // if else için kısa yazılış
            int time = 17;
            string result = (time < 18) ? "Good day."  : "Good evening.";
            Console.WriteLine(result);


            /*
            //switch ile alakalı bir örnek

             int day = 4;
            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;



             //ARRAY İLE İLGİLİ BİR ÖRNEK

            int[,] numbers = { { 1, 4, 2 }, { 3, 6, 8 } };

            for (int i = 0; i < numbers; i++)
            {
                Console.WriteLine(i);
            }




            }
            
             */





        }
    }
}
