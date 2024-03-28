using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Dtos.User;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(DataContext context, IConfiguration configuration, UserService userService) : ControllerBase
{
    private readonly DataContext _context = context;
    private readonly IConfiguration _configuration = configuration;
    private readonly UserService _userService = userService;


    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser(UserRegistrationDto dto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (!await _context.Users.AnyAsync(x => x.Email == dto.Email))
                {
                    var user = await _userService.RegisterUser(dto);
                    if (user != null)
                    {
                        return Created("User registered", null);
                    }
                }

                return Conflict("User already exists");

            }

            return BadRequest("Invalid data");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
