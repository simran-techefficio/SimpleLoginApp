using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public List<UserModel> PutValue()
        {
            var users = new List<UserModel>
            {
                new UserModel{Id=1,username="dileep",password="abc123"},
                new UserModel{Id=2,username="techefficio",password="xyz546"},
            };


            return users;
        }

        [HttpPost]
        public IActionResult Verify(UserModel usr) {
            var u = PutValue();

            var ue = u.Where(u => u.username.Equals(usr.username));
            var up = ue.Where(p => p.password.Equals(usr.password));

            if (up.Count() == 1)
            {
                ViewBag.message = "Login Success";
                return View("LoginSuccess");
            }
            else
            {
                ViewBag.message = "Login Failed";
                return View("Login");
            }
        }
    }
}
