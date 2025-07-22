using LibraryBussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Pages.Categories
{
    [Authorize(Policy = "AdminOnly")]

    public class EditModel : PageModel
    {
        private readonly Swd392Group2Context _context;

        public EditModel(Swd392Group2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;
        public SelectList ParentCategories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = await _context.Categories.FindAsync(id);
            if (Category == null) return NotFound();

            ParentCategories = new SelectList(_context.Categories.Where(c => c.Id != id), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(Category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
