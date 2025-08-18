using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblCurrency
{
    public int Id { get; set; }

    public string? CurrencyCode { get; set; }

    public bool? Status { get; set; }
}
