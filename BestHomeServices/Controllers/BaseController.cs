using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestHomeServices.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
