using LibraryBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryRepositories
{
     public interface IUserRepositories
    {
        List<User> GetAllUsers();

        User? GetUserByEmail(string email);

        void UpdateStatus(int userId, bool status);
        void Create(User user);
    }
}
