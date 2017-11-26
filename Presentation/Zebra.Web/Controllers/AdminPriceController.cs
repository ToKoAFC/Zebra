using System.Web.Mvc;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.View.AdminPrice;

namespace Zebra.Web.Controllers
{
    [Authorize]
    public class AdminPriceController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPriceService _priceService;

        public AdminPriceController(ICategoryService categoryService, IPriceService priceService)
        {
            _categoryService = categoryService;
            _priceService = priceService;
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