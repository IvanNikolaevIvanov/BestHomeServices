using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BestHomeServices.Core.Constants.AdministratorConstants;

namespace BestHomeServices.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        
    }
}
