using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblCorporate
{
    public int Id { get; set; }

    public string? OfficeName { get; set; }

    public string? Address { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public string? PrimaryEmail { get; set; }

    public string? SecondaryEmail { get; set; }

    public string? PrimaryMobile { get; set; }

    public string? SecondaryMobile { get; set; }

    public bool? Status { get; set; }

    public DateOnly? CreateDate { get; set; }
}
