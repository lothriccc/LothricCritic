using EntityLayer.Concrete;
using LothricCritic.Areas.IdentityPanel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LothricCritic.Areas.IdentityPanel.Controllers
{
	[Area("IdentityPanel")]
	[Route("IdentityPanel/[controller]/[action]")]
	public class ProfileController : Controller
	{
		private readonly UserManager<WriterUser> _userManager;

		public ProfileController(UserManager<WriterUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel model = new UserEditViewModel();
			model.Name=values.Name;
			model.Surname = values.Surname;

			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditViewModel p)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			user.Name= p.Name;
			user.Surname= p.Surname;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
			var result = await _userManager.UpdateAsync(user);
			if(result.Succeeded)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
		}
	}
}
