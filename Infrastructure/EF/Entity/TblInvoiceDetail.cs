using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblInvoiceDetail
{
    public string? InvoiceNo { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }
}
