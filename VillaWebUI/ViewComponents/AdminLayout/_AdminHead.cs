using Microsoft.AspNetCore.Mvc;

namespace VillaWebUI.ViewComponents.AdminLayout
{
    public class _AdminHead:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
