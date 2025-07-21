using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryBussiness;
using LibraryRepositories;

namespace LibrarySystem.Pages.Book
{
    public class EditModel : PageModel
    {
        private readonly IBookRepositories _context;

        public EditModel(IBookRepositories context)
        {
            _context = context;
        }

        [BindProperty]
        public LibraryBussiness.Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  _context.GetBookById(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
           ViewData["CategoryId"] = new SelectList(_context.GetAllBooks(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UpdateBook(Book);

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.GetAllBooks().Any(e => e.Id == id);
        }
    }
}
