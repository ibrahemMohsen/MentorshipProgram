using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorshipProgram.Models;


public class MenteeModel
{
    [Key]
    public string UserName { get; set; } 
    [ForeignKey("UserName")]
    public UserModel User { get; set; }
    public List<string> Interests { get; set; } = new List<string>();
}
