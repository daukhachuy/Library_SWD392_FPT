using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryBussiness;
using LibraryRepositories;

namespace LibrarySystem.Pages.Book
{
    public class DeleteModel : PageModel
    {
        private readonly IBookRepositories _context;

        public DeleteModel(IBookRepositories context)
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

            var book = _context.GetBookById(id.Value);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = _context.GetBookById(id.Value);
            _context.DeleteBook(book);
            return RedirectToPage("./Index");
        }
    }
}
