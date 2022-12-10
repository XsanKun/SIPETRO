using Microsoft.AspNetCore.Mvc;
using LoginSipetro.Services;

namespace LoginSipetro.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService AccountService)
        {
            accountService= AccountService;
        }

        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            var account = accountService.Login(username, password);
            if(account != null) 
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("welcome");
            } else
            {
                ViewBag.msg = "Invalid";
                return View("Index");
            }
        }

        [Route("welcome")]
        public IActionResult Welcome()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            return View("welcome");
        }  
        
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("index");
        }
    }
}
