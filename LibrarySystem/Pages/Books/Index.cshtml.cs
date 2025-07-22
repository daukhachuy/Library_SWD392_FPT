using LibraryBussiness;
using LibraryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace LibraryWeb.Pages.Books
{
    [Authorize(Roles = "User")]
    public class IndexModel : PageModel
    {
        private readonly IBookService _bookService;
        private readonly IBorrowRecordService _borrowRecordService;

        public IndexModel(IBookService bookService, IBorrowRecordService borrowRecordService)
        {
            _bookService = bookService;
            _borrowRecordService = borrowRecordService;
        }

        public List<Book> Books { get; set; } = new();
        public HashSet<int> BorrowedBookIds { get; set; } = new();
        public List<BorrowRecord> BorrowedRecords { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public IActionResult OnGet()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return RedirectToPage("/Index");
            }

            int userId = int.Parse(userIdClaim.Value);

            Books = _bookService.GetAllBooks();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Books = Books
                    .Where(b => b.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            BorrowedRecords = _borrowRecordService
                .GetUnreturnedRecordsByUser(userId)
                .Where(r => r.Status != "Returned")
                .ToList();

            BorrowedBookIds = BorrowedRecords
                .Where(r => r.BookId.HasValue)
                .Select(r => r.BookId.Value)
                .ToHashSet();

            return Page();
        }
    }
}
