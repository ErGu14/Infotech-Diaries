namespace Lesson15_Struct_Yapilar
{
    public struct SampleStruct
    {
        public int x;
        public string text;

        public void MyMethod()
        {
            Console.WriteLine("Bu metot (struct) içindedir)");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //class bellekteki heap tarafından tutulurken struct ise bellekteki STACK tarafından tutulur.
            // Bunun farkı bize şunu anlatır : Heap tarafındaki reference değişkenler işi bittiğinde yok edilmeyip,Garbage collector adlı bir mekanizma tarafından bizim kontrolümüz dışında yok edilmeyi beklerler
            //STACK tarafındaki değişkenşer yani value type değişkenler ise işleri bittiğinde bellekten kendiliğindne yok edilirler.
            //performans açısından daha iyi.
            SampleStruct sampleStruct = new SampleStruct();
            sampleStruct.MyMethod();

        }
    }
}
