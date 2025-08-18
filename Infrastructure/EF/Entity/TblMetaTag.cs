using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblMetaTag
{
    public int Id { get; set; }

    public string? SerialCode { get; set; }

    public string? Title { get; set; }

    public string? Keyword { get; set; }

    public string? Descriptiondata { get; set; }
}
