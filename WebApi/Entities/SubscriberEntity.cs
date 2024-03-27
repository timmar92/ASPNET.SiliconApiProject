using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;

public class SubscriberEntity
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public bool DailyNews { get; set; } = false;
    public bool Advertising { get; set; } = false;
    public bool WeekReview { get; set; } = false;
    public bool Events { get; set; } = false;
    public bool Startups { get; set; } = false;
    public bool Podcasts { get; set; } = false;
}
