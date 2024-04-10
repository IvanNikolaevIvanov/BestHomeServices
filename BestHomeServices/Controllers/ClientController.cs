using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Client;
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

        public ClientController(
            ILogger<HomeController> logger,
            IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
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

        [HttpPost]
        public async Task<IActionResult> RemoveSpecialistFromClient(int specialistId)
        {
            if (!await _clientService.ClientExistsAsync(User.Id()))
            {
                return BadRequest();
            }

            
        }
    }
}
