using Microsoft.AspNetCore.Mvc;

namespace VillaWebUI.ViewComponents.AdminLayout
{
    public class _AdminFooter:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();    
        }
    }
}
