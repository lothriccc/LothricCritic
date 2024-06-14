using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LothricCritic.Areas.GamePanel.Controllers
{
    [Area("GamePanel")]
    public class PlatformGameController : Controller
    {
        PlatformGameManager platformGameManager = new PlatformGameManager(new EfPlatformGameDal());
        public IActionResult Index()
        {
            var values = platformGameManager.TGetAll();
            return View(values);
        }
        [HttpGet]
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
        public IActionResult AddPlatformGame(PlatformGame platformGame)
        {
            platformGameManager.TAdd(platformGame);
            return RedirectToAction("Index");
        }
        public IActionResult DeletePlatformGame(int id)
        {
            var values = platformGameManager.TGetByID(id);
            platformGameManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPlatformGame(int id)
        {
            var values = platformGameManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPlatformGame(PlatformGame platformGame)
        {
            platformGameManager.TUpdate(platformGame);
            return RedirectToAction("Index");
        }
    }
}
