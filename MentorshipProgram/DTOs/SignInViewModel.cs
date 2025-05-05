using System.ComponentModel.DataAnnotations;

namespace MentorshipProgram.DTOs;

public class SignInViewModel
{
    [Required]
    [EmailAddress]
    [Length(8, 100)]
    public string UserName { get; set; }
    [Required]
    [EmailAddress]
    [Length(8, 100)]
    public string Password { get; set; }

}
