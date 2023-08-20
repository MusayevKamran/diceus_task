using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    // Using the Authorize attribute establishes that this controller (and any inheriting from it)
    // requires the user to be authenticated to access any of the actions within.
    // BaseController is a custom abstraction above the built-in Controller class in ASP.NET.
    // All controllers that need authorization can inherit from this BaseController to enforce user authentication.
    [Authorize]
    public class BaseController : Controller
    {
    }
}
