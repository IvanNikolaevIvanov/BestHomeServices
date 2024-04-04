using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Home;
using BestHomeServices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BestHomeServices.Controllers
{
    public class HomeController : Controller
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

        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.AllCategories();
            var model = new AllCategoriesIndexServiceModel();
            model.Categories = categories;

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
