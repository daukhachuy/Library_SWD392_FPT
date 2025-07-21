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
    public class DetailsModel : PageModel
    {
        private readonly IBookRepositories _context;

        public DetailsModel(IBookRepositories context)
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
    }
}
