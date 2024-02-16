using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCRMCore.Data;
using MiniCRMCore.Data.Services;
using MiniCRMCore.Data.Services.Interfaces;
using MiniCRMCore.Interfaces;
using MiniCRMCore.Models;

namespace MiniCRMCore.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRepository<User> _repository;
        public AuthController(MiniCRMDbContext db)
        {
            _userService = new UserService(db);
            _repository = new RepositoryUser(db);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login([FromBody]string name, string password)
        {
            var user = new User { Name = name, Password = password };
            if(user != null)
            {
                if (_userService.IfExist(user))
                {
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    return NotFound();
                }
            }
            return NoContent() ;
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if(user != null)
            {
                if (!_userService.IfExist(user))
                {
                    _repository.Create(user);
                    return View("Login");
                }
                return NotFound();
            }
            return NoContent();
        }

       
    }
}
