using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblSessionLog
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }
}
