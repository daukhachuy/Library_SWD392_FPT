using LibraryBussiness;
using LibraryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

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

        [BindProperty]
        public Book? SelectedBook { get; set; }

        public IActionResult OnGet(int? bookId)
        {
            if (bookId == null)
            {
                return RedirectToPage("/Books/Index");
            }

            SelectedBook = _bookService.GetBookById(bookId.Value);

            if (SelectedBook == null)
            {
                return RedirectToPage("/Books/Index");
            }

            return Page();
        }

        public IActionResult OnPostBorrow(int bookId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return RedirectToPage("/Index");

            int userId = int.Parse(userIdClaim.Value);

            var book = _bookService.GetBookById(bookId);
            if (book == null || book.Quantity <= 0)
            {
                TempData["ErrorMessage"] = "Sách không còn để mượn!";
                return RedirectToPage("/Books/Index");
            }

            // 🔒 Check: User đã mượn và chưa trả?
            var hasUnreturned = _borrowRecordService
                .GetUnreturnedRecordsByUser(userId)
                .Any(r => r.BookId == bookId);

            if (hasUnreturned)
            {
                TempData["ErrorMessage"] = "Bạn đã mượn sách này và chưa trả.";
                return RedirectToPage("/Books/Index");
            }

            // ✅ Ghi nhận mượn
            _borrowRecordService.CreateBorrowRecord(new BorrowRecord
            {
                UserId = userId,
                BookId = bookId,
                BorrowDate = DateOnly.FromDateTime(DateTime.Now),
                DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(14)),
                ReturnDate = null,
                Status = "Borrowed"
            });

            _bookService.DecreaseQuantity(bookId);

            TempData["SuccessMessage"] = "Mượn sách thành công!";
            return RedirectToPage("/Books/Index");
        }


    }
}
