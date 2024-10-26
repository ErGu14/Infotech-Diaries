using System;

internal class Program
{
    static int BasamakToplami(int sayi)
    {
        int toplam = 0;
        while (sayi != 0)
        {
            toplam += sayi % 10; // Son basamağı ekle
            sayi /= 10; // Son basamağı çıkar
        }
        return toplam;
    }
    static void Main(string[] args)
    {
        //  45. Girilen bir sayının basamaklarının toplamını bulan program yazın.
        Console.Write("Bir sayı giriniz: ");
        int sayi = int.Parse(Console.ReadLine());

        int toplam = BasamakToplami(sayi);

        Console.WriteLine($"{sayi} sayısının basamaklarının toplamı: {toplam}");
    }

    
}