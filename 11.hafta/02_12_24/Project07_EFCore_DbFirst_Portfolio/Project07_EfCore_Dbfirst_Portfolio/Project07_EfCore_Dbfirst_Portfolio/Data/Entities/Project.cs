using System;
using System.Collections.Generic;

namespace Project07_EfCore_Dbfirst_Portfolio.Data.Entities;

public partial class Project
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string SubTitle { get; set; } = null!;

    public string? Description { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string Team { get; set; } = null!;

    public string? Url { get; set; }

    public string? GitHubUrl { get; set; }

    public string? ZipFileUrl { get; set; }

    public int CatgorieId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Category Catgorie { get; set; } = null!;
}
