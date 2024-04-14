using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Areas.Admin.Controllers
{
    public class ClientController : AdminBaseController
    {
        private readonly IClientService clientService;

        public ClientController(IClientService _clientService)
        {
            clientService = _clientService;
        }

        public async Task<IActionResult> AllClients()
        {
            var model = await clientService.GetAllClientsAsync();

            return View(model);
        }
    }
}
