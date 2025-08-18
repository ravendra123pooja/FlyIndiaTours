using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblCompany
{
    public int Id { get; set; }

    public int? Srno { get; set; }

    public string? CompanyCode { get; set; }

    public string? ShortName { get; set; }

    public string? Website { get; set; }

    public string? PhotoPath { get; set; }

    public string? CompanyName { get; set; }

    public string? Address { get; set; }

    public string? Pincode { get; set; }

    public string? State { get; set; }

    public string? City { get; set; }

    public int? CountryId { get; set; }

    public string? MobileNo { get; set; }

    public string? Email { get; set; }

    public string? PaymentEmail { get; set; }

    public string? Gst { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateDate { get; set; }
}
