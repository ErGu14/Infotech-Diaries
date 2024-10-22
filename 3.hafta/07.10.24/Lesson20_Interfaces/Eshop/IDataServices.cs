using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20_Interfaces.Eshop
{
    internal interface IDataServices
    {
        void Create(); //veri tabanına yei kayıt ekle
        void Update(); // kayıt güncelle
        void Delete(); // Kayıt sil
        void GetAll(); // Kayıtları listele
    }
}
