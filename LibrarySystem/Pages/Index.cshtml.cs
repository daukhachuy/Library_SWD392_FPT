using LibraryBussiness;
using LibraryRepositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace LibrarySystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepositories _context;

        public IndexModel(IUserRepositories context)
        {
            _context = context;
        }
        [BindProperty]
        public User user { get; set; }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToPage("/BookCrud/Index");
                }
                if (User.IsInRole("User"))
                {
                    return RedirectToPage("/BorrowBooks/Index");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var account = _context.GetUserByEmail(user.Email);
            if (account != null)
            {
                var checkPass = account.Password.Equals(user.Password);
                if (!checkPass)
                {
                    ModelState.AddModelError(string.Empty, "PassWord incorrect.");
                    return Page();
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, account.Email),
                        new Claim(ClaimTypes.Name, account.Username),
                        new Claim(ClaimTypes.Role, account.Role)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,
                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                        });

                    if (account.Role.Equals("Admin"))
                    {
                        return RedirectToPage("/BookCrud/Index");
                    }
                    if (account.Role.Equals("User"))
                    {
                        return RedirectToPage("");
                    }

                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email does not exist");

            }
            return Page();
        }
    }
}
