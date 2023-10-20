using Microsoft.AspNetCore.Mvc;

namespace WebApplication_Blog.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
