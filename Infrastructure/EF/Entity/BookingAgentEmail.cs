using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class BookingAgentEmail
{
    public string? AgentCode { get; set; }

    public string? Email { get; set; }
}
