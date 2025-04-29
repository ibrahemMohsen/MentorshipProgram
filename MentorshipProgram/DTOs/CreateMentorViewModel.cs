using MentorshipProgram.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MentorshipProgram.DTOs;

public class CreateMentorViewModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    [Length(8, 100)]
    public string Password { get; set; }
    [Required]
    [Range(0, 40)]
    public int YearsOfExperience { get; set; }
    [Required]
    public string Field { get; set; }
}
