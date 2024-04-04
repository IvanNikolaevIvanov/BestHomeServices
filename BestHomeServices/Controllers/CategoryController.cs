using BestHomeServices.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

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


        public async Task<IActionResult> Hire()
        {
            return View();
        }
    }
}
