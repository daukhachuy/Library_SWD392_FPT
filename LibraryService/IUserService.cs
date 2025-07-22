using LibraryBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User? GetUserByEmail(string email);

        void UpdateStatus(int userId, bool status);
        void Register(User user);
        bool CheckEmailExists(string email);
    }
}
