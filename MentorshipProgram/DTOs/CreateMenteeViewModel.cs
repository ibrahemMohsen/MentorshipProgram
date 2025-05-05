using MentorshipProgram.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MentorshipProgram.DTOs;

public class CreateMenteeViewModel
{
    [Required]
    [EmailAddress]
    [Length(8,100)]
    public string UserName { get; set; }
    [Required]
    [Length(8, 100)]
    public string Name { get; set; }
    [Required]
    [Length(8, 100)]
    public string Password { get; set; }
    [Required]
    [Length(1, 50)]
    public string Field { get; set; }
    [Required]
    public string Interests { get; set; }
}
