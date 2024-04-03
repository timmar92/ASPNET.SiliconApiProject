using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Filters;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class ContactController(ContactService contactService) : ControllerBase
    {
        private readonly ContactService _contactService = contactService;

        [HttpPost]
        public async Task<IActionResult> SendContactFormAsync(ContactFormDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contactForm = await _contactService.CreateContactFormAsync(dto);
                    if (contactForm != null)
                    {
                        return Created();
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
