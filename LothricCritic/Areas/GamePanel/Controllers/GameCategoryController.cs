using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LothricCritic.Areas.GamePanel.Controllers
{

    [Area("GamePanel")]
    [Route("GamePanel/GameCategory")]
    public class GameCategoryController : Controller
	{
		GameCategoryManager gameCategoryManager = new GameCategoryManager(new EfGameCategoryDal());
		[Route("")]
		[Route("Index")]
		public IActionResult Index()
		{
			var values = gameCategoryManager.TGetListWithInclude();
			return View(values);
		}
		

        [HttpGet]
        [Route("")]
        [Route("AddGameCategory")]
        public IActionResult AddGameCategory()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> values1 = (from x in categoryManager.TGetAll()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.vc = values1;

            GameManager gameManager = new GameManager(new EfGameDal());
            List<SelectListItem> values2 = (from x in gameManager.TGetAll()
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.GameID.ToString()
                                            }).ToList();
            ViewBag.vg = values2;

            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("AddGameCategory")]
        public IActionResult AddGameCategory(GameCategory gameCategory)
        {
            gameCategoryManager.TAdd(gameCategory);
            return RedirectToAction("Index");
        }
    }
}
