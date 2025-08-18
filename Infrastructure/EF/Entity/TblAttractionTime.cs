using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblAttractionTime
{
    public int Id { get; set; }

    public string? AttractionName { get; set; }

    public string? ShowsAtractionTimeFrom { get; set; }

    public string? ShowsAtractionTimeTo { get; set; }
}
