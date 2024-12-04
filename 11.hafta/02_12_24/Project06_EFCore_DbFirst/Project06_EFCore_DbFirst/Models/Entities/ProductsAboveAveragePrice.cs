using System;
using System.Collections.Generic;

namespace Project06_EFCore_DbFirst.Models.Entities;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
