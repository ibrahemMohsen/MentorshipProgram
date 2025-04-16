using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorshipProgram.Models;

public class MentorModel
{
    [Key]
    public string UserName { get; set; }
    [ForeignKey("UserName")]
    public UserModel User { get; set; }
    [Required]
    public int YearsOfExperience { get; set; }

    public MentorModel(UserModel User, int YearsOfExperience)
    {
        this.User = User;
        this.YearsOfExperience = YearsOfExperience;
    }
    public MentorModel() { }
}
