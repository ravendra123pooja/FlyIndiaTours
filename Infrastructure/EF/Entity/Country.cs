using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class Country
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? CountryCode { get; set; }

    public string? CountryName { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateDate { get; set; }
}
