namespace WebApi.Dtos;

public class UpdateCourseDto
{
    public CourseDto Course { get; set; } = null!;
    public DetailsListDto? DetailsList { get; set; }
    public PointListDto? PointList { get; set; }
    public ReviewsDto? Reviews { get; set; }
}
