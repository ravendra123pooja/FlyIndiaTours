using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class TblOtp
{
    public int Id { get; set; }

    public string? Otp { get; set; }

    public string? EmailId { get; set; }

    public string? LoginFrom { get; set; }

    public DateTime? CreateDate { get; set; }
}
