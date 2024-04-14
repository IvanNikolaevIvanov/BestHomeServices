using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Areas.Admin.Controllers
{
    public class SpecialistController : AdminBaseController
    {
        private readonly ISpecialistService specialistService;

        public SpecialistController(ISpecialistService _specialistService)
        {
            specialistService = _specialistService;
        }

        public async Task<IActionResult> AllSpecialists()
        {
            var model = await specialistService.GetAllSpecialistsAsync();

            return View(model);
        }
    }
}
