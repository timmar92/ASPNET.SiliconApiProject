namespace WebApi.Dtos;

public class AuthorDto
{
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = "/images/placeholder-image.svg";
    public string? Description { get; set; }
    public string YoutubeUrl { get; set; } = "https://www.youtube.com/";
    public string FacebookUrl { get; set; } = "https://www.facebook.com/";
}
