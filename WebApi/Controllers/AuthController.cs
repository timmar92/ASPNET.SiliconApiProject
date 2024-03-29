using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class AuthController(TokenService tokenService) : ControllerBase
{
    private readonly TokenService _tokenService = tokenService;

    [HttpGet]
    [Route("token")]
    public IActionResult GetToken()
    {
        try
        {
            var token = _tokenService.GenerateToken();
            if (token != null)
            {
                return Ok(token);
            }
            return Unauthorized();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
