using System.ComponentModel.DataAnnotations;
namespace MentorshipProgram.Models;

public class UserModel
{
    [Key]
    public string UserName { get; init; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Name { get; set; }

    public string Field { get; set; }

    //UserModel(string UserName, string Password, string Name)
    //{
    //    this.UserName = UserName;
    //    this.Password = Password;
    //    this.Name = Name;
    //}
}
