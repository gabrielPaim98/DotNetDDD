using Microsoft.AspNetCore.Mvc;

namespace DotNetDDD.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error"), ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Error()
    {
        return Problem();
    }

}
