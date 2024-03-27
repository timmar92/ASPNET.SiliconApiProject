namespace WebApi.Entities;

public class Reviews
{
    public int Id { get; set; }
    public string? ReviewNumbers { get; set; }
    public string? FullStarUrl { get; set; }
    public string? EmptyStarUrl { get; set; }

    public int CourseEntityId { get; set; }
}