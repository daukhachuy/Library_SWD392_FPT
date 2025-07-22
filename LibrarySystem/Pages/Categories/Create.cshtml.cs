using LibraryBussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibrarySystem.Pages.Categories
{
    [Authorize(Policy = "AdminOnly")]

    public class CreateModel : PageModel
    {
        private readonly Swd392Group2Context _context;

        public CreateModel(Swd392Group2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;
        public SelectList ParentCategories { get; set; } = default!;

        public void OnGet()
        {
            ParentCategories = new SelectList(_context.Categories, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
