using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Services;
using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace BestHomeServices.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(
            ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public async Task<IActionResult> AllCategories()
        {
            var model = await categoryService.AllCategoriesAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            var model = new CategoryFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryFormModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryService.AddCategoryAsync(model);

            return RedirectToAction(nameof(AllCategories));
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            if (!await categoryService.ExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await categoryService.GetCategoryFormByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(int id, CategoryDetailsViewModel model)
        {
            if (!await categoryService.ExistsAsync(id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryService.EditAsync(id, model);

            return RedirectToAction(nameof(AllCategories));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!await categoryService.ExistsAsync(id))
            {
                return BadRequest();
            }

            var categoryToDelete = await categoryService.GetCategoryFormByIdAsync(id);

            var model = new CategoryViewModel()
            {
                Id = id,
                Title = categoryToDelete.Title,
                Description = categoryToDelete.Description,
                ImgUrl = categoryToDelete.ImgUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(CategoryViewModel model)
        {
            if (!await categoryService.ExistsAsync(model.Id))
            {
                return BadRequest();
            }

            await categoryService.DeleteCategoryAsync(model.Id);

            return RedirectToAction(nameof(AllCategories));
        }

    }
}
