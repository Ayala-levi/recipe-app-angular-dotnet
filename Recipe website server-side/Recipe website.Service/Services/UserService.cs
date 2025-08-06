using Recipe_website.Core.Repositories_Interface;
using Recipe_website.Core.Services_Interface;
using Recipe_website.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Recipe_website.Service.Services
{
    public class UserService: IUserService { 

        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        } 

        //שליפת כל המשתמשים
        public List<User> Get()
        {
            return _userRepository.Get();
        }       
        
        //שליפת משתמש על פי מייל וסיסמה
        public User GetUser(string Email, string PasswordHash)
        {
            return _userRepository.GetUser(Email, PasswordHash);
        }

        //הוספת משתמש
        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }
    }
}
