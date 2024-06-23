using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LothricCritic.Areas.GamePanel.Controllers
{
    [Area("GamePanel")]
	[Route("GamePanel/PlatformGame")]
	public class PlatformGameController : Controller
    {
        PlatformGameManager platformGameManager = new PlatformGameManager(new EfPlatformGameDal());
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = platformGameManager.TGetListWithInclude();
            return View(values);
        }
        [HttpGet]
		[Route("")]
		[Route("AddPlatformGame")]
		public IActionResult AddPlatformGame()
        {
            PlatformManager platformManager = new PlatformManager(new EfPlatformDal());
            List<SelectListItem> values1 = (from x in platformManager.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.PlatformName,
                                               Value = x.PlatformID.ToString()
                                           }).ToList();
            ViewBag.vp = values1;

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
		[Route("AddPlatformGame")]
		public IActionResult AddPlatformGame(PlatformGame platformGame)
        {
            platformGameManager.TAdd(platformGame);
            return RedirectToAction("Index");
        }
        //[Route("DeletePlatformGame/{id}")]
        //public IActionResult DeletePlatformGame(int id1,int id2)
        //{
        //    var values = platformGameManager.TGetByTwoID(id1,id2);
        //    platformGameManager.TDelete(values);
        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //[Route("EditPlatformGame/{id}")]
        //public IActionResult EditPlatformGame(int id1, int id2)
        //{
        //    var values = platformGameManager.TGetByTwoID(id1,id2);
        //    return View(values);
        //}
        //[HttpPost]
        //[Route("EditPlatformGame/{id}")]
        //public IActionResult EditPlatformGame(PlatformGame platformGame)
        //{
        //    platformGameManager.TUpdate(platformGame);
        //    return RedirectToAction("Index");
        //}
    }
}
