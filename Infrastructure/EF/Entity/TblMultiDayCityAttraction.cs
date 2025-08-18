using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblMultiDayCityAttraction
{
    public string? SerialCode { get; set; }

    public string? GroupTourAttractionCity { get; set; }

    public int? GroupTourAttractionId { get; set; }

    public string? AttractionCostPerPerson { get; set; }

    public int? AttractionDayDuringTour { get; set; }
}
