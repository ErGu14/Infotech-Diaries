

 
   c#'ta değişken tanımlama ve isimlendirme kuralları


 1- Değişken isimleri Türkçe karakter içermemelidir.
 string İlyas = "merhaba ben ilyas"; // düzgün hali Ilyas olmalı

 2- Değişken isimleri büyük ve küçük harf duyarlıdır.
 string ciCek = "gül";
 string cicek = "gül";        //yandaki iki örnekte değişkenler tamamen farklı ama camelCase kuralına uymadığı için çok tavsiye edilmiyor



 3- Değişken isimlerinde ilk karakter bir sayı olamaz.
 int 1sayi = 1; //düzgün hali : int sayi1 = 1;

  4-Değişken isimlerinde JavaScript etiketleri kullanılamaz. (if,while,for,...)
 int if = 15;
 string for = "merhaba";

 5-Değişken isimlerinde sayı, harf, alt çizgi ve dolar işareti kullanılabilir; boşluk, noktalama işareti veya sembol kullanılamaz.
 int number 1 = 3;
 string name.surname = "Ahmet Hürgezen";
