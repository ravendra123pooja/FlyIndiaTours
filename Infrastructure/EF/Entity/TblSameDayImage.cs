using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblSameDayImage
{
    public int Id { get; set; }

    public string? SerialCode { get; set; }

    public string? Images { get; set; }

    public string? ImageTitle { get; set; }
}
