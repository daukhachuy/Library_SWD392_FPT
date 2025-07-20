using LibraryBussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Pages.Book
{
    public class CreateModel : PageModel
    {
        private readonly LibraryBussiness.Swd392Group2Context _context;

        public CreateModel(LibraryBussiness.Swd392Group2Context context)
        {
            _context = context;
        }
        [Authorize(Policy = "AdminOnly")]
        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public LibraryBussiness.Book  Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
