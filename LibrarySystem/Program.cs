using LibraryBussiness;
using LibraryRepositories;
using LibraryService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Swd392Group2Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStringDB")));

            builder.Services.AddScoped<IUserRepositories, UserRepositories>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IBookRepositories, BookRepositories>();
            builder.Services.AddScoped<IBorrowRecordRepository, BorrowRecordRepository>();
            builder.Services.AddScoped<IBookService, Bookservice>();
            builder.Services.AddScoped<IBorrowRecordService, BorrowRecordService>();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/Index";
                   options.LogoutPath = "/Account/Logout";
                   options.AccessDeniedPath = "/AccessDenied";
               });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("AdminOrUser", policy => policy.RequireRole("Admin", "User"));
            });

            builder.Services.AddRazorPages();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}