using System.Web.Mvc;
using Zebra.Services.Interfaces;

namespace Zebra.Web.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
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