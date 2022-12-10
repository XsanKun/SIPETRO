using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class TransferController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            return View();
        }
    }
}
