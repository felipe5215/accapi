using Microsoft.AspNetCore.Mvc;

namespace Bacana.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet(Name = "createUser")]
    public string Get()
    {
        return "sdfsdfsdf asdasdn!";
    }
}
