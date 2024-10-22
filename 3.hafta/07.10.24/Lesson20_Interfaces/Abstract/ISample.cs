using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20_Interfaces.Abstract
{
    internal interface ISample
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        void DisplayInfo();
        int GetCount();
    }
}
