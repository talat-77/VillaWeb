using Microsoft.AspNetCore.Mvc;

namespace VillaWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
