using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Client;
using BestHomeServices.Core.Models.Specialist;
using BestHomeServices.Core.Services;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BestHomeServices.Controllers
{
    public class ClientController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientService _clientService;
        private readonly ISpecialistService specialistService;

        public ClientController(
            ILogger<HomeController> logger,
            IClientService clientService,
            ISpecialistService _specialistService)
        {
            _logger = logger;
            _clientService = clientService;
            specialistService = _specialistService;
        }

        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            var model = new ShowClientInfoModel();

            model = await _clientService.GetClientInfoByUserId(User.Id());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            if (!await _clientService.ClientExistsAsync(User.Id()))
            {
                return BadRequest();
            }

            var model = new ClientInfoForm();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientInfoForm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _clientService.EditInfoAsync(User.Id(), model);

            return RedirectToAction(nameof(ClientController.MyProfile), "Client");
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {

            if (!await specialistService.SpecialistExistsAsync(id))
            {
                return BadRequest();
            }

            if (!await _clientService.ClientExistsAsync(User.Id()))
            {
                return BadRequest();
            }

            var specialist = await specialistService.GetSpecialistByIdAsync(id);

            var model = new SpecialistViewModel()
            {
                Id = id,
                FirstName = specialist.FirstName,
                LastName = specialist.LastName,
                ImageUrl = specialist.ImageUrl,
                PhoneNumber = specialist.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(SpecialistViewModel model)
        {
            if (!await specialistService.SpecialistExistsAsync(model.Id))
            {
                return BadRequest();
            }

            if (!await _clientService.ClientExistsAsync(User.Id()))
            {
                return BadRequest();
            }

            await _clientService.RemoveSpecialistFromClient(User.Id(), model.Id);

            return RedirectToAction(nameof(MyProfile), "Client");
        }
    }
}
