﻿using System;
using System.Collections.Generic;

namespace LibraryBussiness;

public partial class BorrowRecord
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? BookId { get; set; }

    public DateOnly? BorrowDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string? Status { get; set; }

    //public int? Rating { get; set; }         // 1-5 sao
    //public string? ReviewComment { get; set; }
    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
