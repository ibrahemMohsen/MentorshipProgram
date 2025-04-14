using System.ComponentModel.DataAnnotations;

namespace MentorshipProgram.Models;

public class MentorModel
{
    [Key]
    public UserModel User { get; set; }
    [Required]
    public int YearsOfExperience { get; set; }

}
