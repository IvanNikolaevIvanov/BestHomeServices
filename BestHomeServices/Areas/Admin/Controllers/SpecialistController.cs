using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Areas.Admin.Controllers
{
    public class SpecialistController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
