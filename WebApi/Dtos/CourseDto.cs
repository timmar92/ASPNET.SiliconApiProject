namespace WebApi.Dtos;

public class CourseDto
{
    public string Title { get; set; } = null!;
    public string? Subtitle { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? ArticleNumber { get; set; }
    public string? DownloadResource { get; set; }
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Hours { get; set; }
    public bool IsBestSeller { get; set; } = false;
    public string? LikesInNumbers { get; set; }
    public string? LikesInPercent { get; set; }
}
