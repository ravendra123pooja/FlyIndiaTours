using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class Usermaster
{
    public int Id { get; set; }

    public string? PhotoPath { get; set; }

    public string? UserCode { get; set; }

    public int? Srno { get; set; }

    public string? Name { get; set; }

    public string? FatherName { get; set; }

    public string? Address { get; set; }

    public string? Pincode { get; set; }

    public string? State { get; set; }

    public string? City { get; set; }

    public int? CountryId { get; set; }

    public DateTime? Dob { get; set; }

    public string? Designation { get; set; }

    public int? RoleId { get; set; }

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Pancard { get; set; }

    public string? AddressProof { get; set; }
}
