using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LothricCritic.Areas.GamePanel.Controllers
{
    [Area("GamePanel")]
    [Route("GamePanel/Category")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = categoryManager.TGetAll();
            return View(values);
        }
        [HttpGet]
        [Route("")]
        [Route("AddCategory")]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("AddCategory")]
        public IActionResult AddCategory(Category category)
        {
            categoryManager.TAdd(category);
            return RedirectToAction("Index");
        }
        [Route("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var values = categoryManager.TGetByID(id);
            categoryManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("EditCategory/{id}")]
        public IActionResult EditCategory(int id)
        {
            var values = categoryManager.TGetByID(id);
            return View(values);

        }
        [HttpPost]
        [Route("EditCategory/{id}")]
        public IActionResult EditCategory(Category category)
        {
            categoryManager.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
