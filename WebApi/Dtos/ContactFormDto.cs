namespace WebApi.Dtos;

public class ContactFormDto
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? SelectedOption { get; set; }
    public string Message { get; set; } = null!;
}
