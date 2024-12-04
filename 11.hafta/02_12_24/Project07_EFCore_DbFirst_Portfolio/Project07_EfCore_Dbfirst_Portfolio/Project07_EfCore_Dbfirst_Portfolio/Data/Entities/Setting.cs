using System;
using System.Collections.Generic;

namespace Project07_EfCore_Dbfirst_Portfolio.Data.Entities;

public partial class Setting
{
    public int? Id { get; set; }

    public string SiteName { get; set; } = null!;

    public string FooterText { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
