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
    public class IndexModel : PageModel
    {
        private readonly LibraryBussiness.Swd392Group2Context _context;

        public IndexModel(LibraryBussiness.Swd392Group2Context context)
        {
            _context = context;
        }

        public IList<LibraryBussiness.Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.Category).ToListAsync();
        }
    }
}
