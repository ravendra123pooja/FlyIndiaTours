using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblBillToCompany
{
    public int Id { get; set; }

    public string? PhotoPath { get; set; }

    public string? CompanyName { get; set; }

    public string? Address { get; set; }

    public string? Pincode { get; set; }

    public string? State { get; set; }

    public string? City { get; set; }

    public int? CountryId { get; set; }

    public string? MobileNo { get; set; }

    public string? Email { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateDate { get; set; }
}
