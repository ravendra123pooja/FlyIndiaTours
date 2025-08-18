using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblMenuPerMision
{
    public int Id { get; set; }

    public Guid? MenuId { get; set; }

    public int? RoleId { get; set; }

    public bool? Create { get; set; }

    public bool? Update { get; set; }

    public bool? Delete { get; set; }

    public bool? View { get; set; }

    public bool? Print { get; set; }

    public bool? Details { get; set; }

    public bool? Download { get; set; }
}
