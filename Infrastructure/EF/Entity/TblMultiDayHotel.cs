using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblMultiDayHotel
{
    public string? SerialCode { get; set; }

    public string? GroupTourHotelCity { get; set; }

    public string? GroupTourHotelCategory { get; set; }

    public int? GroupTourHotelId { get; set; }
}
