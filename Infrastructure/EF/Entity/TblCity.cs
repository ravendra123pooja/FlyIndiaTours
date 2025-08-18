using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblCity
{
    public int Id { get; set; }

    public int? CountryId { get; set; }

    public string? CityName { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateDate { get; set; }
}
