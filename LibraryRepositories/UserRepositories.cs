using LibraryBussiness;
using LibraryDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryRepositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly UserDao _userDao;
        public UserRepositories()
        {
            _userDao = new UserDao();
        }
        public List<User> GetAllUsers() => UserDao.GetAllUsers();

        public User? GetUserByEmail(string email) => UserDao.GetUserByEmail(email);

        public void UpdateStatus(int userId, bool status) => UserDao.UpdateStatus(userId,status);


        public void Create(User user)
        {
            _userDao.Insert(user);
        }
    }
}
