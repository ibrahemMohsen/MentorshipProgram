using System.ComponentModel.DataAnnotations;
namespace MentorshipProgram.Models;

public class UserModel
{
    [Key]
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Name { get; set; }
    
    public string Field { get; set; }

    public UserModel(string UserName, string Password, string Name)
    {
        this.UserName = UserName;
        this.Password = Password;
        this.Name = Name;
    }
    public UserModel() { }
}
