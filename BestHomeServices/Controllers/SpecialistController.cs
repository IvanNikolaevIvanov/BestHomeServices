using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.Specialist;
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

        [HttpGet]
        public async Task<IActionResult> Hire(int specialistId)
        {
            var model = new HireSpecialistFormModel() 
            {
                SpecialistId = specialistId
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Hire(HireSpecialistFormModel model)
        {
            if (await specialistService.SpecialistExistsAsync(model.SpecialistId) == false)
            {
                ModelState.AddModelError(nameof(model.SpecialistId), "Specialist doesn't exist");
            }


            return View(model);
        }
    }
}
