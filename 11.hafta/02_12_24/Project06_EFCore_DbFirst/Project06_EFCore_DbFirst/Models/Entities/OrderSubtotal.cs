using System;
using System.Collections.Generic;

namespace Project06_EFCore_DbFirst.Models.Entities;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
