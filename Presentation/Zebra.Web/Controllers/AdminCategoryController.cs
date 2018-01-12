using System.Web.Mvc;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.View.AdminCategory;

namespace Zebra.Web.Controllers
{
    [Authorize]
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

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
            var model = new VMCategory();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VMCategory model)
        {
            _categoryService.SaveCategory(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int categoryId)
        {
            var model = _categoryService.GetCategory(categoryId);
            return View("Create", model);
        }

        public ActionResult Delete(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            return RedirectToAction("Index");
        }
    }
}