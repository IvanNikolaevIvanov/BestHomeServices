using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace BestHomeServices.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;

        public CategoryController(
            ILogger<HomeController> logger,
            ICategoryService _categoryService)
        {
            _logger = logger;
            categoryService = _categoryService;
        }

        
        [HttpGet]
        public async Task<IActionResult> SelectCategory(int id)
        {

            if (await categoryService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await categoryService.CategoryDetailsByIdAsync(id);

            return View(model);

        }

        
    }
}
