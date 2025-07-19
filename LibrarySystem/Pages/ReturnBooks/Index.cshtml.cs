using LibraryBussiness;
using LibraryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LibraryWeb.Pages.ReturnBooks
{
    public class IndexModel : PageModel
    {
        private readonly IBorrowRecordService _borrowRecordService;
        private readonly IBookService _bookService;

        public IndexModel(IBorrowRecordService borrowRecordService, IBookService bookService)
        {
            _borrowRecordService = borrowRecordService;
            _bookService = bookService;
        }

        public List<BorrowRecord> BorrowedBooks { get; set; }

        public void OnGet()
        {
            int userId = 1;
            BorrowedBooks = _borrowRecordService.GetUnreturnedRecordsByUser(userId);
        }

        public IActionResult OnPostReturn(int recordId, int bookId)
        {
            _borrowRecordService.MarkAsReturned(recordId);
            _bookService.IncreaseQuantity(bookId);
            return RedirectToPage("Index");
        }
    }
}
