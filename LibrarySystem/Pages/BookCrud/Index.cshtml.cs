using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryBussiness;
using Microsoft.AspNetCore.Authorization;

namespace LibrarySystem.Pages.Book
{
    [Authorize(Policy = "AdminOnly")] 
    public class IndexModel : PageModel
    {
        private readonly LibraryBussiness.Swd392Group2Context _context;

        public IndexModel(LibraryBussiness.Swd392Group2Context context)
        {
            _context = context;
        }

        public IList<LibraryBussiness.Book> Book { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var books = _context.Books.Include(b => b.Category).AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(b => b.Title.Contains(SearchString) || b.Author.Contains(SearchString));
            }

            Book = await books.ToListAsync();
        }
    }
}