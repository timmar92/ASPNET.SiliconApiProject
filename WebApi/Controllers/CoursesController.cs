using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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


    //[HttpGet]
    //public async Task<IActionResult> GetCoursesAsync()
    //{
    //    try
    //    {
    //        var courses = await _courseService.GetAllCoursesAsync();
    //        if (courses == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(courses);
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
    //    }
    //}

    [HttpGet]
    public async Task<IActionResult> GetCoursesQueryAsync(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 10)
    {
        try
        {
            var query = _courseService.GetAllCoursesAsQueryable();
            if (query == null)
            {
                return NotFound();
            }
            if(!string.IsNullOrEmpty(category) && category != "all")
            {
                query = query.Where(c => c.Category!.CategoryName == category);
            }
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(x => x.Title.Contains(searchQuery) || x.Author!.Name.Contains(searchQuery));
            }

            query = query.OrderByDescending(c => c.Id);

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var courseList = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            var result = new
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                Courses = courseList
            };

            

            return Ok(result);
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
