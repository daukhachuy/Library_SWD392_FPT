using System;
using System.Collections.Generic;

namespace LibraryBussiness;

public partial class Reservation
{
    public int Id { get; set; }

    public int? BookId { get; set; }

    public DateOnly? ReservedDate { get; set; }

    public string? Status { get; set; }

    public virtual Book? Book { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
