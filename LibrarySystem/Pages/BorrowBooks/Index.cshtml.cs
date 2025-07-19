using System;
using LibraryBussiness;
using LibraryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWeb.Pages.BorrowBooks
{
    public class IndexModel : PageModel
    {
        private readonly IBookService _bookService;
        private readonly IBorrowRecordService _borrowRecordService;

        public IndexModel(IBookService bookService, IBorrowRecordService borrowRecordService)
        {
            _bookService = bookService;
            _borrowRecordService = borrowRecordService;
        }

        public List<Book> AvailableBooks { get; set; }

        public IActionResult OnGet()
        {
            AvailableBooks = _bookService.GetAvailableBooks();
            return Page();
        }

        public IActionResult OnPostBorrow(int bookId)
        {
            // TODO: Get user ID from session or auth
            int userId = 1;

            if (!_bookService.IsBookAvailable(bookId))
                return RedirectToPage("Index");

            _borrowRecordService.CreateBorrowRecord(new BorrowRecord
            {
                UserId = userId,
                BookId = bookId,
                BorrowDate = DateOnly.FromDateTime(DateTime.Now),
                DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(14)),
                ReturnDate = null
            });

            _bookService.DecreaseQuantity(bookId);
            return RedirectToPage("Index");
        }
    }
}
