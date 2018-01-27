using System.Web.Mvc;
using Zebra.Services.Interfaces;

namespace Zebra.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService { get; set; }
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }
    }
} 