using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblRoleMaster
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public bool? Status { get; set; }
}
