using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }

        public async Task<IActionResult> Categories()
        {
            return View();
        }
    }
}
