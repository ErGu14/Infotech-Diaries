namespace Lesson07_Operatorler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1- aritmetik operatörler
            /*
                        int num1 = 10;
                        int num2 = 2;*/
            /* Console.WriteLine($"numara1 : {num1} \nnumara2 : {num2}");
             Console.WriteLine();
             Console.WriteLine($"Toplam = {num1 + num2}");
             Console.WriteLine();
             Console.WriteLine($"Fark = {num1 - num2}");
             Console.WriteLine();
             Console.WriteLine($"Çarpım = {num1 * num2}");
             Console.WriteLine();
             Console.WriteLine($"Bölüm = {num1 / num2}");
             Console.WriteLine();
             Console.WriteLine($"Mod = {num1 % num2}");*/
            //Console.WriteLine();
            /*num1++;
            Console.WriteLine(num1); // ++ operatörü kullanıldığı değişkenin işini yaptıktan sonra değerini 1 arttırır.

            num1--;
            Console.WriteLine(num1); // değerini 1 eksiltir.

            Console.WriteLine(++num1); // ++ operatörü sona yazılmışsa işini yaptıktan sonra 1 arttırır ama önüne yazılmışsa önce değerini 1 arttırır sonra kullanır.
            Console.WriteLine(++num1); // -- operatörü sona yazılmışsa işini yaptıktan sonra 1 azaltır ama önüne yazılmışsa önce değerini 1 azaltır sonra kullanır.*/

            int a = 7;
            int b = 21;
            int c = 11;

            /*Console.WriteLine(a++ + b++ + c + --a + ++b );*/

            // 2- İlişkisel Operatörler

             int num1 = 10;
             int num2 = 15;
             int num3 = 10;
            
            /*
             Console.WriteLine($"num1 num2 den büyük mü?: {num1>num2}");
             Console.WriteLine($"num1 num2 den büyük yoksa eşit mi?: {num1>=num2}");
             Console.WriteLine($"num1 num2 den küçük mü?: {num1<num2}");
             Console.WriteLine($"num1 num2 den küçük yoksa eşit mi?: {num1<=num2}");
             Console.WriteLine($"num1 num2  eşit mi?: {num1==num2}");
             Console.WriteLine($"num1 num2  eşit değil mi?: {num1!=num2}");
 */

            // 3- Mantıksal operatörler
            Console.WriteLine(num1==num2 || num1 == num3);
            Console.WriteLine(num1==num2 && num1 == num3);


        }
    }
}
