using LibraryBussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibrarySystem.Pages.Categories
{
    [Authorize(Policy = "AdminOnly")]

    public class DeleteModel : PageModel
    {

        private readonly Swd392Group2Context _context;

        public DeleteModel(Swd392Group2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = await _context.Categories.FindAsync(id);
            if (Category == null) return NotFound();

            Category.Parent = await _context.Categories.FindAsync(Category.ParentId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var category = await _context.Categories.FindAsync(Category.Id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
