using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class HotelCreation
{
    public int Id { get; set; }

    public string? HotelName { get; set; }

    public string? HotelCategory { get; set; }

    public string? CityName { get; set; }

    public string? HotelLocation { get; set; }

    public string? WebsiteLink { get; set; }

    public string? Description { get; set; }

    public string? HotelPicture { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? HotelStar { get; set; }
}
