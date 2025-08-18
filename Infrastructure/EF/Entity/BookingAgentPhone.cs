using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class BookingAgentPhone
{
    public string? AgentCode { get; set; }

    public string? CountryCode { get; set; }

    public string? CityCode { get; set; }

    public string? PhoneNo { get; set; }
}
