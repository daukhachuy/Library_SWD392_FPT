using System;
using System.Collections.Generic;

namespace LibraryBussiness;

public partial class Payment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public decimal? Amount { get; set; }

    public string? Reason { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
