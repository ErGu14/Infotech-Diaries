namespace ClassWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
           OkulDAL okulDAL = new OkulDAL(834,"Emirhan","ÇüklüBayan",100,85,90,"İnfotech");
            okulDAL.OgrenciBilgileriGetir();
            okulDAL.OgrenciOrtalamaBul();
            okulDAL.GetSchool();
           
            
        }
    }
}
