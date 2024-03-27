using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Filters;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class SubscribersController(SubscriberService subscriberService) : ControllerBase
{
    private readonly SubscriberService _subscriberService = subscriberService;


    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscriberDto dto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (!await _subscriberService.SubscriberExists(dto.Email))
                {
                    await _subscriberService.CreateSubscriberAsync(dto);
                    return Created("", null);
                }
                else
                {
                    return Conflict("Subscriber already exists");
                }
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{email}")]
    public async Task<IActionResult> Unsubscribe(string email)
    {
        try
        {
            var result = await _subscriberService.DeleteSubscriber(email);
            if (result == true)
            {
                return NoContent();
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
