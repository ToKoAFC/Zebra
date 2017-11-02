using System.Web.Mvc;
using Zebra.Services;
using Zebra.ViewModels.View.AdminProducts;

namespace Zebra.Web.Controllers
{
    [Authorize]
    public class AdminProductsController : Controller
    {
        public ProductService _productService { get; set; }
        public AdminProductsController()
        {
        }

        public ActionResult Index()
        {
            var products = _productService.GetProducts();
            var model = new VMAdminProductsIndex
            {
                Products = products
            };
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new VMAdminProductsCreate();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VMAdminProductsCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userName = User.Identity.Name;
            _productService.SaveProduct(model, userName);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int productId)
        {
            var model = _productService.GetProductForEdition(productId);
            return View("Create", model);
        }
        
        public ActionResult Delete(int productId)
        {
            _productService.DeleteProduct(productId);
            return RedirectToAction("Index");
        }
    }
}