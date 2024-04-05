namespace WebApi.Dtos;

public class CreateCourseDto
{
    public CourseDto Course { get; set; } = null!;
    public AuthorDto? Author { get; set; }
    public DetailsListDto? DetailsList { get; set; }
    public PointListDto? PointList { get; set; }
    public ReviewsDto? Reviews { get; set; }
    public CategoryDto? Category { get; set; }
}
