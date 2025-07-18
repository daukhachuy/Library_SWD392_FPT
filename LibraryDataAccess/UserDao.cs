using LibraryBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataAccess
{
    public class UserDao
    {
        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                using var _context = new Swd392Group2Context();
                users = _context.Users.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error get all Users : {ex.Message}");
            }
            return users;
        }

         public static User? GetUserByEmail(string email)
        {
            User? user = null;
            try
            {
                using var _context = new Swd392Group2Context();
                user = _context.Users.FirstOrDefault(U => U.Email.Equals(email));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error get  User by email: {ex.Message}");
            }
            return user;
        }

        public static void UpdateStatus(int userId, bool status)
        {
            try
            {
                using var _context = new Swd392Group2Context();
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.Status = status;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error update User status: {ex.Message}");
            }
        }
    }
}
