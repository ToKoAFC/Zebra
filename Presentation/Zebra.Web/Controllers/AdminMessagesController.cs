using System.Web.Mvc;
using Zebra.Services;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.Common;
using Zebra.ViewModels.View.AdminCategory;

namespace Zebra.Web.Controllers
{
    [Authorize]
    public class AdminMessagesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}