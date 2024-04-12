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
        private readonly ICityService cityService;

        public SpecialistController(
            ILogger<HomeController> logger,
            ICategoryService _categoryService,
            ISpecialistService _specialistService,
            IClientService _clientService,
            ICityService _cityService)
        {
            _logger = logger;
            categoryService = _categoryService;
            specialistService = _specialistService;
            clientService = _clientService;
            cityService = _cityService;
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

                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var specialist = await specialistService.GetSpecialistByIdAsync(model.SpecialistId);
            var specialistCity = await cityService.GetCityByIdAsync(specialist.CityId);

            if (await clientService.ClientExistsAsync(User.Id()) == false)
            {
                await clientService.AddClientAsync(User.Id(), model.ClientName, model.ClientAddress, model.ClientCity, model.ClientPhoneNumber);
            }
            
            var client = await clientService.GetClientEntityByUserIdAsync(User.Id());
            var clientCity = await cityService.GetCityByIdAsync(client.CityId);

            if (specialistCity.Name != clientCity.Name)
            {
                ModelState.AddModelError(nameof(clientCity.Name), "Specialist doesn't operate in this area");

                return BadRequest(ModelState);
            }
            else
            {
                await specialistService.HireSpecialistByIdAsync(specialist, client);


                return RedirectToAction(nameof(ClientController.MyProfile), "Client");
            }
            
        }
    }
}
