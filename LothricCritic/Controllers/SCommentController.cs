using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LothricCritic.Controllers
{
	public class SCommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EfCommentDal());
		private readonly UserManager<WriterUser> _userManager;

		public SCommentController(UserManager<WriterUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		[AllowAnonymous]
		[HttpPost]
		public IActionResult PartialAddComment(Comment comment)
		{
			
			ViewBag.u= User.Identity.IsAuthenticated;
			var user = User.Identity.IsAuthenticated;
			var username = User.Identity.Name;
			if(user==true)
			{
				comment.UserName = username;
				commentManager.TAdd(comment);
				return RedirectToAction("GameDetails", "SGame",new {id = comment.GameID});
			}
			else
			{
				return RedirectToAction("Index","Login", new {area="IdentityPanel"});
			}
		}
	}
}
