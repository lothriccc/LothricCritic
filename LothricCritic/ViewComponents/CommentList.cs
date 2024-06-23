using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace LothricCritic.ViewComponents
{
	public class CommentList : ViewComponent
	{
		CommentManager commentManager = new CommentManager(new EfCommentDal());
		public IViewComponentResult Invoke(int id)
		{
			var values = commentManager.TGetAll(id);
			return View(values);
		}
	}
}
