using Microsoft.EntityFrameworkCore;
using Recipe_website.Core.Repositories_Interface;
using Recipe_website.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_website.Data.Repositories
{
    public class UserRepository: IUserRepository
    {
        //מופע של DataContext
        //המשמש לאינטראקציה עם מסד הנתונים
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        //שליפת כל המשתמשים
        public List<User> Get()
        {
            return _context.Users.Include(u=>u.Recipes).ToList();
        }

        //שליפת משתמש על פי מייל וסיסמה
        public User GetUser(string Email, string PasswordHash)
        {
            return _context.Users.FirstOrDefault(u => u.Email == Email && u.PasswordHash == PasswordHash);
        }

        //הוספת משתמש
        public User AddUser(User user)
        {
            var u=_context.Users.Add(user);
            _context.SaveChanges();
            return u.Entity;
           
        }
    }
}
