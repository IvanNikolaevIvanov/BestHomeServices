using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Areas.Admin.Controllers
{
    public class ClientController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
