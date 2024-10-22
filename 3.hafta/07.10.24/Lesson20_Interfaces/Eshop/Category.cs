using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20_Interfaces.Eshop
{
    internal class Category : IBase, IDataServices
    {



        public int Id { get ; set; }
        public string Name {
            get {
                return Name;
                    
             } 
            set {

                if (value.Length >= 5)
                {
                    Name = value;
                }
                else {
                    new ArgumentException("İsim 5 karakterden kısa olamaz!");
                }
            
            } }
        public DateTime CreatedDate { get ; set ; }
        public DateTime ModifiedDate { get ; set ; }

        public  string? Description { get; set; }
        public bool IsShowMenu { get; set; }

         //******//
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
