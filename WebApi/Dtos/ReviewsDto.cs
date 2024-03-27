namespace WebApi.Dtos;

public class ReviewsDto
{
    public string? ReviewNumbers { get; set; }
    public string FullStarUrl { get; set; } = "/images/full-star.svg";
    public string EmptyStarUrl { get; set; } = "/images/empty-star.svg";
}
