﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp_Home.Models.SupplierModels
{
    internal class UpdateSupplierModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}