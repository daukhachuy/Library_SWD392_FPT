using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryBussiness;

public partial class User
{
    [Required(ErrorMessage = "Tên không được để trống")]
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    public string? Password { get; set; }

    public string? Role { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
