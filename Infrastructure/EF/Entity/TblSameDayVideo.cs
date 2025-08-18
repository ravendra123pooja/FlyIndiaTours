using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblSameDayVideo
{
    public int Id { get; set; }

    public string? SerialCode { get; set; }

    public string? VideoUrl { get; set; }
}
