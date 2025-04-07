using Microsoft.AspNetCore.Mvc;

namespace VillaWebUI.ViewComponents.AdminLayout
{
    public class _AdminNavbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
