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

        public async Task<IActionResult> AllCities([FromQuery] AllCitiesQueryModel model)
        {
            var queryResult = await cityService.GetAllCitiesAsync(
                model.currentPage,
                model.citiesPerPage);

            model.totalCitiesCount = queryResult.totalCitiesCount;
            model.Cities = queryResult.Cities;

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
