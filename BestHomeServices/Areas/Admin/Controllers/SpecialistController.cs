using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.Specialist;
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

        [HttpGet]
        public IActionResult AddSpecialist()
        {
            var model = new AddSpecialistFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSpecialist(AddSpecialistFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await specialistService.AddSpecialistAsync(model);

            return RedirectToAction(nameof(AllSpecialists));
        }

        [HttpGet]
        public async Task<IActionResult> EditSpecialist(int id)
        {
            if (!await specialistService.SpecialistExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await specialistService.GetSpecialistFormByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSpecialist(int id, AddSpecialistFormModel model)
        {
            if (!await specialistService.SpecialistExistsAsync(id))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await specialistService.EditSpecialistAsync(id, model);

            return RedirectToAction(nameof(AllSpecialists));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSpecialist(int id)
        {
            if (!await specialistService.SpecialistExistsAsync(id))
            {
                return BadRequest();
            }

            var specialistToDelete = await specialistService.GetSpecialistFormByIdAsync(id);

            var model = new SpecialistViewModel()
            {
                Id = id,
                FirstName = specialistToDelete.FirstName,
                LastName = specialistToDelete.LastName,
                Description = specialistToDelete.Description,
                ImageUrl = specialistToDelete.ImageUrl,
                PhoneNumber = specialistToDelete.PhoneNumber

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSpecialist(SpecialistViewModel model)
        {
            if (!await specialistService.SpecialistExistsAsync(model.Id))
            {
                return BadRequest();
            }

            await specialistService.DeleteSpecialistAsync(model.Id);

            return RedirectToAction(nameof(AllSpecialists));
        }
    }
}
