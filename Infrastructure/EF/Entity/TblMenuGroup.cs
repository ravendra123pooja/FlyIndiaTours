using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblMenuGroup
{
    public int MenuGroupId { get; set; }

    public string? ManuGroupName { get; set; }

    public int? ParantGroupId { get; set; }

    public int? Seq { get; set; }

    public string? Icon { get; set; }

    public bool? Active { get; set; }

    public int? Type { get; set; }
}
