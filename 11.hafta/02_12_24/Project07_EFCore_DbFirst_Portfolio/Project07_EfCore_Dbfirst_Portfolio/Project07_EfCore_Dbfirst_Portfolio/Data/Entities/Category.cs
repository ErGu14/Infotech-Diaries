using System;
using System.Collections.Generic;

namespace Project07_EfCore_Dbfirst_Portfolio.Data.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
