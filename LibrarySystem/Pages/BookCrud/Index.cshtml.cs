using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryBussiness;
using Microsoft.AspNetCore.Authorization;
using LibraryRepositories;

namespace LibrarySystem.Pages.Book
{
    [Authorize(Policy = "AdminOnly")] 
    public class IndexModel : PageModel
    {
        private readonly IBookRepositories _context;

        public IndexModel(IBookRepositories context)
        {
            _context = context;
        }

        public IList<LibraryBussiness.Book> Book { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            Book =  _context.GetAllBooks().ToList();
        }
    }
}