using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;

public class ContactEntity
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? SelectedOption { get; set; }
    public string Message { get; set; } = null!;
}
