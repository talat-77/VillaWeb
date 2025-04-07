using Microsoft.AspNetCore.Mvc;

namespace VillaWebUI.ViewComponents.AdminLayout
{
    public class _AdminSidebarMenu:ViewComponent
    {
      public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
