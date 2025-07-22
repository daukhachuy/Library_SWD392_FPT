using LibraryBussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Pages.Categories
{
    [Authorize(Policy = "AdminOnly")]

    public class DetailsModel : PageModel
    {
        private readonly Swd392Group2Context _context;

        public DetailsModel(Swd392Group2Context context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = await _context.Categories
                .Include(c => c.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Category == null) return NotFound();

            return Page();
        }
    }

}
