using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
