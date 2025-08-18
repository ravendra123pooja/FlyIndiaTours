using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class BookingAgentStatus
{
    public int? BookingAgentId { get; set; }

    public string? Status { get; set; }

    public DateTime StatusChangeDateTime { get; set; }

    public string? StatusChangeReason { get; set; }
}
