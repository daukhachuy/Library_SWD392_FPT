using LibraryBussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Pages.Categories
{
    [Authorize(Policy = "AdminOnly")]

    public class IndexModel : PageModel
    {
        private readonly Swd392Group2Context _context;

        public IndexModel(Swd392Group2Context context)
        {
            _context = context;
        }

        public List<Category> Categories { get; set; } = new();

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.Include(c => c.Parent).ToListAsync();
        }
    }

}
