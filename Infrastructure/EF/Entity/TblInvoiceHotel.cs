using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblInvoiceHotel
{
    public int Id { get; set; }

    public string? HotelName { get; set; }

    public string? Address { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public bool? Status { get; set; }

    public DateOnly? CreateDate { get; set; }
}
