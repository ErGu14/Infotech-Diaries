using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork
{
    internal class OkulDAL
    {
        private int OgrenciNo { get; set; }
        private string Name { get; set; }
        private string LastName { get; set; }
        private int Vize1 { get; set; }
        private int Vize2 { get; set; }
        private int final { get; set; }
        private string SchoolName { get; set; }

        public OkulDAL(int _OgrenciNo, string _Name, string _LastName, int _Vize1, int _Vize2, int _final, string _SchoolName)
        {
            
            OgrenciNo = _OgrenciNo;
            Name = _Name;
            LastName = _LastName;
            Vize1 = _Vize1;
            Vize2 = _Vize2;
            final = _final;
            SchoolName = _SchoolName;

        }

        public void OgrenciBilgileriGetir()
        {
            Console.WriteLine($"Öğrenci No: {OgrenciNo}\nÖğrenci Ad Soyad: {Name + " " + LastName}\nOkul Adı :{SchoolName}");


                                  
        }
        public void OgrenciOrtalamaBul()
        {
            int result = (Vize1 + Vize2 +final) / 3;
            Console.WriteLine($"Ortalama : {result}");
            
        }
        public void GetSchool()
        {
            Console.WriteLine(SchoolName);
        }


    }
}
