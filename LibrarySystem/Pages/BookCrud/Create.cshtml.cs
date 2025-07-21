using LibraryBussiness;
using LibraryRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace LibrarySystem.Pages.Book
{
    public class CreateModel : PageModel
    {
        private readonly IBookRepositories _context;

        public CreateModel(IBookRepositories context)
        {
            _context = context;
        }
        [Authorize(Policy = "AdminOnly")]
        public IActionResult OnGet()
        {
            
        ViewData["CategoryId"] = new SelectList(_context.GetAllBooks(), "Id", "Name");
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

            _context.AddBook(Book);

            return RedirectToPage("./Index");
        }
    }
}
