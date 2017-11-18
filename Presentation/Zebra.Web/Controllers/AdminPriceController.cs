using System.Web.Mvc;
using Zebra.Services;
using Zebra.ViewModels.View.AdminPrice;

namespace Zebra.Web.Controllers
{
    [Authorize]
    public class AdminPriceController : Controller
    {
        public CategoryService _categoryService { get; set; }
        public PriceService _priceService { get; set; }
        public AdminPriceController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var categories = _categoryService.GetCategorySelectList();
            var model = new VMAdminPriceCreate
            {
                Categories = categories                
            };
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VMAdminPriceCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userName = User.Identity.Name;
            //_productService.SaveProduct(model, userName);
            return RedirectToAction("Index");
        }

    }
}