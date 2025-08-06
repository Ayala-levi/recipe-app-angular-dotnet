using Recipe_website.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_website.Core.Repositories_Interface
{
    public interface IUserRepository
    {
       
        //שליפת כל המשתמשים
        public List<User> Get();

        //שליפת משתמש על פי מייל וסיסמה
        public User GetUser(string Email, string PasswordHash);
        
        //הוספת משתמש
        public User AddUser(User user);
    }
}
