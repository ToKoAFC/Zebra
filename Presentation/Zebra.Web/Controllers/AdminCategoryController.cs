using System.Web.Mvc;

namespace Zebra.Web.Controllers
{
    public class AdminCategoryController : Controller
    {
        public AdminCategoryController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}