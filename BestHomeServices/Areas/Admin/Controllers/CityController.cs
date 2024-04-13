using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Areas.Admin.Controllers
{
    public class CityController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
