namespace WebApi.Dtos;

public class SubscriberDto
{
    public string Email { get; set; } = null!;
    public bool DailyNews { get; set; } = false;
    public bool Advertising { get; set; } = false;
    public bool WeekReview { get; set; } = false;
    public bool Events { get; set; } = false;
    public bool Startups { get; set; } = false;
    public bool Podcasts { get; set; } = false;
}
