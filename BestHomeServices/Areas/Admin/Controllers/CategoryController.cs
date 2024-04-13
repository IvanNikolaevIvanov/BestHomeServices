using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
