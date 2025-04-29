using System.ComponentModel.DataAnnotations;

namespace MentorshipProgram.DTOs;

public class MentoringFilterViewModel
{
    [Required]
    [Range(0, 50)]
    public int YearsOfExperience { get; set; }
    [Required]
    public string Field { get; set; }
}
