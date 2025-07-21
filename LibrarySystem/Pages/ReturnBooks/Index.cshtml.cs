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

        [BindProperty]
        public BorrowRecord? SelectedRecord { get; set; }

        public IActionResult OnGet(int? recordId)
        {
            if (recordId == null)
            {
                return RedirectToPage("/Books/Index");
            }

            SelectedRecord = _borrowRecordService.GetById(recordId.Value);

            if (SelectedRecord == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy bản ghi mượn.";
                return RedirectToPage("/Books/Index");
            }

            return Page();
        }

        public IActionResult OnPostReturn(int recordId, int bookId)
        {
            _borrowRecordService.ReturnBook(recordId); // ✅ gọi logic đã xử lý cả cập nhật số lượng & trạng thái

            TempData["SuccessMessage"] = "Trả sách thành công.";
            return RedirectToPage("/Books/Index"); // ✅ Quay về trang Books để cập nhật
        }


    }
}
