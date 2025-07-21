using LibraryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibrarySystem.Pages.Review
{
    public class SubmitModel : PageModel
    {
        private readonly IBorrowRecordService _borrowRecordService;

        public SubmitModel(IBorrowRecordService borrowRecordService)
        {
            _borrowRecordService = borrowRecordService;
        }

        [BindProperty]
        public int BorrowRecordId { get; set; }

        [BindProperty]
        public int Rating { get; set; }

        [BindProperty]
        public string Comment { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            try
            {
                //_borrowRecordService.SubmitReview(BorrowRecordId, Rating, Comment);
                TempData["Message"] = "Đánh giá thành công!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToPage("/BorrowHistory");
        }
    }

}
