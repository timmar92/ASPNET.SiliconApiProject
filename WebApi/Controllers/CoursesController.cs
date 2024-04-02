using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Filters;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class CoursesController(CourseService courseService) : ControllerBase
{
    private readonly CourseService _courseService = courseService;


    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCourseDto dto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (!await _courseService.CourseExistsAsync(dto.Course.Title))
                {
                    var course = await _courseService.CreateCourseAsync(dto);
                    if (course != null)
                    {
                        return Created();
                    }
                }

                return Conflict("Course already exists");

            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
        return BadRequest();
    }


    [HttpGet]
    public async Task<IActionResult> GetCoursesAsync()
    {
        try
        {
            var courses = await _courseService.GetAllCoursesAsync();
            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetCoursebyIdAsync(int id)
    {
        try
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourseAsync(int id, UpdateCourseDto dto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var course = await _courseService.GetCourseByIdAsync(id);
                if (course == null)
                {
                    return NotFound();
                }

                var updatedCourse = await _courseService.UpdateCourseAsync(id, dto);
                if (updatedCourse == true)
                {
                    return NoContent();
                }
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

    }


    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourseAsync(int id)
    {
        try
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            var deletedCourse = await _courseService.DeleteCourseAsync(id);
            if (deletedCourse == true)
            {
                return NoContent();
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


}
