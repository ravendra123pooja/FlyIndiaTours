using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblMultiDayPackageDate
{
    public string? SerialCode { get; set; }

    public string? GroupTourStartDate { get; set; }

    public string? GroupTourEndDate { get; set; }

    public int? DefaultBlockedSeatsEachTrip { get; set; }
}
