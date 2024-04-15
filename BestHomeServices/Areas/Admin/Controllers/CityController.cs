using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.City;
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

        [HttpGet]
        public IActionResult AddCity()
        {
            var model = new CityFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await cityService.AddCityAsync(model);

            return RedirectToAction(nameof(AllCities));
        }
    }
}
