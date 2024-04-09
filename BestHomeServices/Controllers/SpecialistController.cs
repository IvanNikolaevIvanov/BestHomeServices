using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.Specialist;
using BestHomeServices.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BestHomeServices.Controllers
{
    public class SpecialistController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;
        private readonly ISpecialistService specialistService;
        private readonly IClientService clientService;

        public SpecialistController(
            ILogger<HomeController> logger,
            ICategoryService _categoryService,
            ISpecialistService _specialistService,
            IClientService _clientService)
        {
            _logger = logger;
            categoryService = _categoryService;
            specialistService = _specialistService;
            clientService = _clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Hire(int id)
        {
            if (await specialistService.SpecialistExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = new HireSpecialistFormModel()
            {
                SpecialistId = id
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

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await clientService.ClientExistsAsync(User.Id()) == false)
            {
                await clientService.AddClientAsync(User.Id(), model.ClientName, model.ClientAddress, model.ClientCity, model.ClientPhoneNumber);
            }
            
            await specialistService.HireSpecialistByIdAsync(model.SpecialistId, User.Id());

           
            return RedirectToAction(nameof(ClientController.All), "Client");
        }
    }
}
