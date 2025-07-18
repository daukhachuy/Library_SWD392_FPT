using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryBussiness;

namespace LibrarySystem.Pages.Book
{
    public class DetailsModel : PageModel
    {
        private readonly LibraryBussiness.Swd392Group2Context _context;

        public DetailsModel(LibraryBussiness.Swd392Group2Context context)
        {
            _context = context;
        }

        public LibraryBussiness.Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
