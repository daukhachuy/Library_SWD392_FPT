using LibraryBussiness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Pages
{
    public class GuestIndexModel : PageModel
    {
        private readonly Swd392Group2Context _context;

        public GuestIndexModel(Swd392Group2Context context)
        {
            _context = context;
        }

        public List<LibraryBussiness.Book> Books { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            var query = _context.Books
                .Include(b => b.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(b => b.Title.Contains(SearchTerm));
            }

            Books = await query.ToListAsync();
        }
    }
}
