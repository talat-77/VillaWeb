using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using Villa.DTO.Dtos.IdentityDtos;
using Villa.Entity.Entities;

namespace VillaWebUI.Controllers
{
	public class AcountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

        public AcountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
		{
			return View();
		}
		[HttpPost]	
		public async Task<IActionResult> Register(RegisterDto registerDto)
		{
			var user = new ApplicationUser()
			{
				NameSurname=registerDto.Namesurname,
				Email = registerDto.Email,
				UserName=registerDto.Username
			};
			var result= await _userManager.CreateAsync(user,registerDto.Password);	
			if (!result.Succeeded)
			{
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
				return View();
            }
			return RedirectToAction("Login");
		}
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]	
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
			var user = await _userManager.FindByNameAsync(loginDto.Username);
			if (user==null)
			{
				ModelState.AddModelError("","Kullanıcı Adı Veya Şifre Hatalı");
				return View();
			}
			var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
			if (!result.Succeeded) {

				ModelState.AddModelError("","Kullanıcı adı veya Şifre Hatalı");
				return View();
			}
			return RedirectToAction("Index","Banner");	
			
		}
	}
}
