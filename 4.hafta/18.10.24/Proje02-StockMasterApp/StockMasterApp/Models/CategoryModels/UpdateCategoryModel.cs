using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp.Models.CategoryModels
{
    internal class UpdateCategoryModel:CategoryCreateOrUpdateModel
    {
        public int Id { get; set; }

    }
}
