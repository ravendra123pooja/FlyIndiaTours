using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblDuration
{
    public int Id { get; set; }

    public string? DurationDays { get; set; }
}
