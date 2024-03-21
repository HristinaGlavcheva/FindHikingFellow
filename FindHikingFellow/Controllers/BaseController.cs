using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindHikingFellow.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
