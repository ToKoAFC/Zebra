using System.Web.Mvc;
using Zebra.Services;

namespace Zebra.Web.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        public ProductService _productService { get; set; }
        public ProductsController()
        {
        }

        public ActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }
    }
}