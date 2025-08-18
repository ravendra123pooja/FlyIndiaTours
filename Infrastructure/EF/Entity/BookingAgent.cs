using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class BookingAgent
{
    public int Id { get; set; }

    public string? AgentCode { get; set; }

    public int? Srno { get; set; }

    public string? BookingAgentName { get; set; }

    public string? NatureOfBusinesss { get; set; }

    public string? BusinessName { get; set; }

    public string? Address { get; set; }

    public int? CountryId { get; set; }

    public string? City { get; set; }

    public string? CountryCode { get; set; }

    public string? UserName { get; set; }

    public string? PassWord { get; set; }

    public string? EnableDisable { get; set; }

    public string? Approval { get; set; }

    public bool? Status { get; set; }

    public DateOnly? CreateDate { get; set; }

    public string? Website { get; set; }

    public string? Photopath { get; set; }
}
