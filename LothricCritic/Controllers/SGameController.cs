using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LothricCritic.Controllers
{
	[AllowAnonymous]
	public class SGameController : Controller
	{
		GameManager gameManager = new GameManager(new EfGameDal());
		private readonly UserManager<WriterUser> _userManager;
		public IActionResult Index()
		{
			var username = User.Identity.Name;
			
			ViewBag.user = username;
			var values = gameManager.TGetGameListWithCompany();
			return View(values);
		}
		public IActionResult GameDetails(int id)
		{
			Context c = new Context();
            ViewBag.commentcount = c.Comments.Count(x => x.GameID==id);
			ViewBag.i= id;
			var values = gameManager.TGetAll(id);
			return View(values);
		}
		//deneme3131
		
	}
}
