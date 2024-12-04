using System;
using System.Collections.Generic;

namespace Project07_EfCore_Dbfirst_Portfolio.Data.Entities;

public partial class ServiceInfo
{
    public int? Id { get; set; }

    public string ServiceTitle { get; set; } = null!;

    public string ServiceText { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
