using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Reddit.API.Controllers.Abstractions;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public abstract class BaseApiController : ControllerBase
{
    // Common functionality for all controllers can be added here
}
