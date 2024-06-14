using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace LothricCritic.Areas.GamePanel.Controllers
{
    [Area("GamePanel")]
    [Route("GamePanel/Company")]
    public class CompanyController : Controller
    {
        CompanyManager companyManager = new CompanyManager(new EfCompanyDal());
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = companyManager.TGetAll();
            return View(values);
        }
        [HttpGet]
        [Route("")]
        [Route("AddCompany")]
        public IActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("AddCompany")]
        public IActionResult AddCompany(Company company)
        {
            companyManager.TAdd(company);
            return RedirectToAction("Index");
        }
        [Route("DeleteCompany/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var values = companyManager.TGetByID(id);
            companyManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("EditCompany/{id}")]
        public IActionResult EditCompany(int id)
        {
            var values = companyManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        [Route("EditCompany/{id}")]
        public IActionResult EditCompany(Company company)
        {
            companyManager.TUpdate(company);
            return RedirectToAction("Index");
        }

    }
}
//ROUTE YAPARKEN EDIT KISMINDA ROUTE İKİ KERE YAZILACAK
