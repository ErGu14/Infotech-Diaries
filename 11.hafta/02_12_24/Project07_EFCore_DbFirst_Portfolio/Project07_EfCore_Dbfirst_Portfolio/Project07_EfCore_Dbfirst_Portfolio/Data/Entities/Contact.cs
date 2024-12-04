using System;
using System.Collections.Generic;

namespace Project07_EfCore_Dbfirst_Portfolio.Data.Entities;

public partial class Contact
{
    public int? Id { get; set; }

    public string Adress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string GoogleMap { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
