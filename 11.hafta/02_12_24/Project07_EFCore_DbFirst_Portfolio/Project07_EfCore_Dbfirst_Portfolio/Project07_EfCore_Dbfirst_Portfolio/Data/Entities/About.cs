using System;
using System.Collections.Generic;

namespace Project07_EfCore_Dbfirst_Portfolio.Data.Entities;

public partial class About
{
    public int? Id { get; set; }

    public string AboutTitle { get; set; } = null!;

    public string AboutText { get; set; } = null!;

    public string AboutCvUrl { get; set; } = null!;

    public string AboutImageUrl { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
