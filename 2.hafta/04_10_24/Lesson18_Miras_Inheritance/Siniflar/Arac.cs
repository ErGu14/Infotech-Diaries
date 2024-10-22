using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18_Miras_Inheritance.Siniflar
{
    internal abstract class Arac
    {
        public string Tur { get; set; }
        public virtual void KornaCal() { // isteğe bağlı miras aldığım sınıfta ezebilirim.
            Console.WriteLine("Kornaya Basıldı");
        }
        public abstract void DisplayInfo(); //gövdesind ekod yok
    }
}
