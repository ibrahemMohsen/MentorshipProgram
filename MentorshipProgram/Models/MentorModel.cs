using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorshipProgram.Models;

public class MentorModel
{
    [Key, ForeignKey(nameof(User))]
    [Required]
    [EmailAddress]
    [Length(8, 100)]
    public string UserName { get; set; }
    public UserModel User { get; set; }
    [Required]
    [Range(0, 60)]
    public int YearsOfExperience { get; set; }

    public MentorModel(UserModel User, int YearsOfExperience)
    {
        this.User = User;
        this.YearsOfExperience = YearsOfExperience;
    }
    public MentorModel() { }
}
