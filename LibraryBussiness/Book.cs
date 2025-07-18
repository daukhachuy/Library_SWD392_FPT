using System;
using System.Collections.Generic;

namespace LibraryBussiness;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Author { get; set; }

    public string? Description { get; set; }

    public bool? Availability { get; set; }

    public int? Quantity { get; set; }

    public int? CategoryId { get; set; }

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
