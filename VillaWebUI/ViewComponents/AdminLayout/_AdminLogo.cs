using Microsoft.AspNetCore.Mvc;
namespace VillaWebUI.ViewComponents.AdminLayout
{
    public class _AdminLogo:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
        return View(); 
        }
    }
}
