using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Home;
using BestHomeServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace BestHomeServices.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;

        public HomeController(
            ILogger<HomeController> logger,
            ICategoryService _categoryService)
        {
            _logger = logger;
            categoryService = _categoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]AllCategoriesIndexServiceModel query)
        {
           
            var model = await categoryService.AllCategoriesAsync(
                query.Cities,
                query.Category);

            query.Categories = model;

            return View(query);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
