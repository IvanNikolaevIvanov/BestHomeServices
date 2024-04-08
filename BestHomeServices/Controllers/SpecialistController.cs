using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Controllers
{
    public class SpecialistController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;
        private readonly ISpecialistService specialistService;

        public SpecialistController(
            ILogger<HomeController> logger,
            ICategoryService _categoryService,
            ISpecialistService _specialistService)
        {
            _logger = logger;
            categoryService = _categoryService;
            specialistService = _specialistService;
        }

        [HttpPost]
        public async Task<IActionResult> Hire(CategoryDetailsViewModel model)
        {



            return View(model);
        }
    }
}
