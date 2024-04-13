using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Areas.Admin.Controllers
{
    public class ProjectController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
