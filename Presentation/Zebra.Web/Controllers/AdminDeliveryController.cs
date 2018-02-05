using System.Web.Mvc;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.AdminCategory.Common;

namespace Zebra.Web.Controllers
{
    [Authorize]
    public class AdminDeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;
        public AdminDeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        public ActionResult Index()
        {
            var deliveries = _deliveryService.GetDeliveries();
            return View(deliveries);
        }

        public ActionResult Create()
        {
            return View(new VMDelivery());
        }
        
        [HttpPost]
        public ActionResult Create(VMDelivery model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _deliveryService.SaveDelivery(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int deliveryId)
        {
            var model = _deliveryService.GetDelivery(deliveryId);
            return View("Create", model);
        }

        public ActionResult Delete(int deliveryId)
        {
            _deliveryService.DeleteDelivery(deliveryId);
            return RedirectToAction("Index");
        }
    }
}