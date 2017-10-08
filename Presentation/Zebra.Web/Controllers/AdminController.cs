using System.Web.Mvc;

namespace Zebra.Web.Controllers
{
    public class AdminController : Controller
    {
        public AdminController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}