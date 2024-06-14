using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace LothricCritic.Areas.GamePanel.Controllers
{
    [Area("GamePanel")]
    [Route("GamePanel/Platform")]
    public class PlatformController : Controller
    {
        PlatformManager platformManager = new PlatformManager(new EfPlatformDal());
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = platformManager.TGetAll();
            return View(values);
        }

        [HttpGet]
        [Route("")]
        [Route("AddPlatform")]
        public IActionResult AddPlatform()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("AddPlatform")]
        public IActionResult AddPlatform(Platform platform)
        {
            platformManager.TAdd(platform);
            return RedirectToAction("Index");
        }
        [Route("DeleteCategory/{id}")]
        public IActionResult DeletePlatform(int id)
        {
            var values = platformManager.TGetByID(id);
            platformManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditPlatform/{id}")]
        public IActionResult EditPlatform(int id)
        {
            var values = platformManager.TGetByID(id);
            return View(values);

        }
        [HttpPost]
        [Route("EditPlatform/{id}")]
        public IActionResult EditPlatform(Platform platform)
        {
            platformManager.TUpdate(platform);
            return RedirectToAction("Index");
        }
    }
}
