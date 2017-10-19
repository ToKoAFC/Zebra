using System.Web.Mvc;

namespace Zebra.Web.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        public ProductsController()
        {
        }

        public ActionResult Index()
        {

            return View();
        }
    }
}