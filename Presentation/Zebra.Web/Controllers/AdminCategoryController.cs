using System.Web.Mvc;
using Zebra.Services;
using Zebra.ViewModels.View.AdminCategory;

namespace Zebra.Web.Controllers
{
    [Authorize]
    public class AdminCategoryController : Controller
    {
        public CategoryService _categoryService { get; set; }

        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            var model = new VMAdminCategoryIndex
            {
                Categories = categories
            };
            return View(model);
        }

        public ActionResult Create()
        {
            var categorySelectList = _categoryService.GetCategorySelectList();
            var model = new VMAdminCategoryCreate
            {
                CategoryList = categorySelectList
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VMAdminCategoryCreate model)
        {
            _categoryService.CreateCategory(model.CategoryName, model.ParentCategoryId);
            return RedirectToAction("Index");
        }
    }
}