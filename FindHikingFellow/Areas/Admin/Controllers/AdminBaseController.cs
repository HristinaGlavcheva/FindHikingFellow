using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static FindHikingFellow.Core.Constants.AdministratorConstants;

namespace FindHikingFellow.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
