using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    /// <summary>
    /// Base controller for API endpoints.
    /// Inherits from ControllerBase and automatically assigns the route for the controller based on its name.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {

    }
}
