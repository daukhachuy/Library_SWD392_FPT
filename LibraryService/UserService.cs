using LibraryBussiness;
using LibraryRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
    public class UserService : IUserService
    {
        private readonly IUserRepositories _userRepositories;

        public UserService(IUserRepositories userRepositories)
        {
            _userRepositories = userRepositories;
        }
        public List<User> GetAllUsers() => _userRepositories.GetAllUsers();

        public User? GetUserByEmail(string email) => _userRepositories.GetUserByEmail(email);

        public void UpdateStatus(int userId, bool status) => _userRepositories.UpdateStatus(userId, status);
    }
}
