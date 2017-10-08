using System.Web.Mvc;

namespace Zebra.Web.Controllers
{
    public class AdminProductsController : Controller
    {
        public AdminProductsController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}