using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Filters;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class CategoriesController(CourseService courseService) : ControllerBase
{
    private readonly CourseService _courseService = courseService;

    [HttpGet]
    public async Task<ActionResult> GetCategoriesAsync()
    {
        try
        {
            var categories = await _courseService.GetAllCategoriesAsync();
            if (categories == null)
            {
                categories = new List<CategoryEntity>();
            }

            return Ok(categories);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }


    }
}
