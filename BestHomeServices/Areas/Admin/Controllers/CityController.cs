using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Areas.Admin.Controllers
{
    public class CityController : AdminBaseController
    {
        private readonly ICityService cityService;

        public CityController(ICityService _cityService)
        {
            cityService = _cityService;
        }

        public async Task<IActionResult> AllCities()
        {
            var model = await cityService.GetAllCitiesAsync();

            return View(model);
        }
    }
}
