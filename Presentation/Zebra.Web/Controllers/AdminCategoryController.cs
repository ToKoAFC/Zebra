using System.Web.Mvc;
using Zebra.Services;

namespace Zebra.Web.Controllers
{
    public class AdminCategoryController : Controller
    {
        public CategoryService _categoryService { get; set; }

        public ActionResult Index()
        {
            var model = _categoryService.GetCategories();
            return View(model);
        }
    }
}