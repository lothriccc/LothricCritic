using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace LothricCritic.Areas.GamePanel.Controllers
{
    [Area("GamePanel")]
    [Route("GamePanel/Game")]
    public class GameController : Controller
    {
        GameManager gameManager = new GameManager(new EfGameDal());
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = gameManager.TGetGameListWithCompany();
            return View(values);
        }
        [HttpGet]
        [Route("")]
        [Route("AddGame")]
        public IActionResult AddGame()
        {
            CompanyManager companyManager = new CompanyManager(new EfCompanyDal());
            List<SelectListItem> values = (from x in companyManager.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text=x.CompanyName,
                                               Value= x.CompanyID.ToString()
                                           }).ToList();
            ViewBag.v= values;
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("AddGame")]
        public IActionResult AddGame(Game game)
        {
            gameManager.TAdd(game);
            return RedirectToAction("Index");
        }
        [Route("DeleteGame/{id}")]
        public IActionResult DeleteGame(int id)
        {
            var values = gameManager.TGetByID(id);
            gameManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("EditGame/{id}")]
        public IActionResult EditGame(int id)
        {
			CompanyManager companyManager = new CompanyManager(new EfCompanyDal());
			List<SelectListItem> values = (from x in companyManager.TGetAll()
										   select new SelectListItem
										   {
											   Text = x.CompanyName,
											   Value = x.CompanyID.ToString()
										   }).ToList();
			ViewBag.v = values;
			var value = gameManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        [Route("EditGame/{id}")]
        public IActionResult EditGame(Game game)
        {
            gameManager.TUpdate(game);
            return RedirectToAction("Index");
        }
    }
}
