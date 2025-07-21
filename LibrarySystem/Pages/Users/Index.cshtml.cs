using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryBussiness;

namespace LibrarySystem.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly LibraryBussiness.Swd392Group2Context _context;

        public IndexModel(LibraryBussiness.Swd392Group2Context context)
        {
            _context = context;
        }

        public IList<User> User { get; set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }

        public IActionResult OnPostStatus(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Status = !user.Status;
            _context.Users.Update(user);
            _context.SaveChanges();
            TempData["Message"] = "Update status acount ( "+user.Username+" ) successfully!";
            User =  _context.Users.ToList();
            return RedirectToPage("./Index");
        }
    }
}
