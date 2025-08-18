using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblMenu
{
    public Guid MenuId { get; set; }

    public string? ManuName { get; set; }

    public string? MenuUrl { get; set; }

    public int? MenuGroupId { get; set; }

    public bool? Active { get; set; }

    public int? SrNo { get; set; }
}
