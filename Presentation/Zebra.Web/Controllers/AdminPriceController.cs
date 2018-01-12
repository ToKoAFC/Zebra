using Microsoft.AspNet.Identity;
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
            var model = _priceService.GetDiscounts();
            return View(model);
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
            var userId = User.Identity.GetUserId();
            _priceService.SaveCategoryDiscount(model, userId);
            return RedirectToAction("Index");
        }

        public ActionResult Active(int discountId)
        {
            _priceService.ChangeDiscountActivity(discountId, true);
            return RedirectToAction("Index");
        }
        public ActionResult Disactive(int discountId)
        {
            _priceService.ChangeDiscountActivity(discountId, false);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int discountId)
        {
            var model = _priceService.GetDiscount(discountId);
            return View("Create", model);
        }
        public ActionResult Delete(int discountId)
        {
            _priceService.DeleteDiscount(discountId);
            return RedirectToAction("Index");
        }
    }
}