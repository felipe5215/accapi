using Microsoft.AspNetCore.Mvc;

namespace Bacana.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "hello")]
    public string Get()
    {
        return "Hello World!";
    }
}
