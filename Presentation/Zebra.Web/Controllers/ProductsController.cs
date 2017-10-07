using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Zebra.Web.Models;
using Zebra.Database.Models;

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