using Authenticate.Models;
using Microsoft.AspNetCore.Mvc;

namespace Authenticate.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    [Route("/hello")]
    public string Get()
    {
        return "hello";
    }
}