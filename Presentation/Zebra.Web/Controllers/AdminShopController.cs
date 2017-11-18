using System.Web.Mvc;
using Zebra.Services;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.Common;
using Zebra.ViewModels.View.AdminCategory;

namespace Zebra.Web.Controllers
{
    [Authorize]
    public class AdminShopController : Controller
    {
        public ShopService _shopService { get; set; }

        public ActionResult Index()
        {
            var shop = _shopService.GetShopInfo();
            var model = new VMAdminShopIndex
            {
                Shop = shop
            };
            return View(model);
        }


        public ActionResult Edit()
        {
            var shop = _shopService.GetShopInfo();
            return View(shop);
        }

        [HttpPost]
        public ActionResult Edit(VMShop model)
        {
            _shopService.SaveShopInfo(model);
            return RedirectToAction("Index");
        }

    }
}