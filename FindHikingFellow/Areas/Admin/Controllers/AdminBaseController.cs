using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static FindHikingFellow.Core.Constants.RoleConstants;

namespace FindHikingFellow.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
