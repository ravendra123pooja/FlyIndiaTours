using System;
using System.Collections.Generic;

namespace Infrastructure.EF.Entity;

public partial class RefreshToken
{
    public int RefreshTokenId { get; set; }

    public string? UserName { get; set; }

    public string? DeviceSerialNumber { get; set; }

    public string? RefreshTokenValue { get; set; }

    public bool? IsRevoked { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ExpiredOn { get; set; }
}
