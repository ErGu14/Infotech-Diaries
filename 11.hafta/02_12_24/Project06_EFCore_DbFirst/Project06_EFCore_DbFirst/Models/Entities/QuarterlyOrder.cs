using System;
using System.Collections.Generic;

namespace Project06_EFCore_DbFirst.Models.Entities;

public partial class QuarterlyOrder
{
    public string? CustomerId { get; set; }

    public string? CompanyName { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }
}
