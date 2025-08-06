using Microsoft.AspNetCore.Mvc;
using Recipe_website.Core.Services_Interface;
using Recipe_website.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe_website.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //בקשות למשתמש
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //שליפת כל המשתמשים
        [HttpGet]
        public List<User> Get()
        {
            try
            {
                return _userService.Get();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //שליפת משתמש על פי מייל וסיסמה
        [HttpGet("{Email},{Password}")]
        public User GetUser(string Email, string Password)
        {
            try
            {
                var user = _userService.GetUser(Email, Password);

                if (user == null)
                {
                    Console.WriteLine("User not found");
                    return null;
                }

                return user;
            }
            catch 
            {
                Console.WriteLine("An error occurred while processing your request.");
                return null;
            }
        }

        //הוספת משתמש
        [HttpPost]
        public User AddUser([FromBody] User user)
        {
            try
            {
                return _userService.AddUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

    }
}
