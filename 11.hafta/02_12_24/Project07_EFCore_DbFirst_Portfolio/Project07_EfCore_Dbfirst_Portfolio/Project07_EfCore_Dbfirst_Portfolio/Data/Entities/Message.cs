using System;
using System.Collections.Generic;

namespace Project07_EfCore_Dbfirst_Portfolio.Data.Entities;

public partial class Message
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Content { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public bool IsRead { get; set; }

    public DateTime? SendingDate { get; set; }

    public DateTime? ReadingDate { get; set; }
}
