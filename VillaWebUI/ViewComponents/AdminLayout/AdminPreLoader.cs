﻿using Microsoft.AspNetCore.Mvc;

namespace VillaWebUI.ViewComponents.AdminLayout
{
    public class AdminPreLoader:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

        return View();
        }

    }
}
