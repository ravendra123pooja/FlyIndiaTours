using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblCancellationPolicy
{
    public int Id { get; set; }

    public int? PerHundred { get; set; }

    public int? PerFifty { get; set; }

    public int? PerTwentyfive { get; set; }
}
