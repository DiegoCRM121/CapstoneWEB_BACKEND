using System;
using System.Collections.Generic;

namespace CapstoneWEB.CORE.Entities;

public partial class User
{
    public int IdUser { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Country { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? IsActive { get; set; }
}
