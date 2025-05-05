using System.ComponentModel.DataAnnotations;
namespace MentorshipProgram.Models;

public class UserModel
{
    [Key]
    [Required]
    [EmailAddress]
    [Length(8, 100)]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Length(8, 100)]
    public string Name { get; set; }
    [Required]
    public string Field { get; set; }

    public UserModel(string UserName, string Password, string Name)
    {
        this.UserName = UserName;
        this.Password = Password;
        this.Name = Name;
    }
    public UserModel() { }
}
