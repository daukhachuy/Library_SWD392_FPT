using LibraryBussiness;
using LibraryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public User User { get; set; }

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (_userService.CheckEmailExists(User.Email))
            {
                ModelState.AddModelError("User.Email", "Email đã tồn tại.");
                return Page();
            }

            if (User.Password.Length < 8)
            {
                ModelState.AddModelError("User.Password", "Mật khẩu phải có ít nhất 8 ký tự.");
                return Page();
            }
            User.Role = "User";

            _userService.Register(User);

            TempData["RegisterSuccess"] = "Đăng ký thành công. Vui lòng đăng nhập.";
            return RedirectToPage("/Index");
        }
    }
}
