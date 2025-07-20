using LibraryBussiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Pages.Book
{
    public class EditModel : PageModel
    {
        private readonly LibraryBussiness.Swd392Group2Context _context;

        public EditModel(LibraryBussiness.Swd392Group2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public LibraryBussiness.Book Book { get; set; } = default!;

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
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

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
