using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14_SiniflarMetodlar.Shoping
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        public  string? Description { get; set; }
        public required string Note { get; set; }

    }
}
