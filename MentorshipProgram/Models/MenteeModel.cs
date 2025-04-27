using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorshipProgram.Models;


public class MenteeModel
{
    [Key, ForeignKey(nameof(User))]
    public string UserName { get; set; } 
    public UserModel User { get; set; }
    public string Interests { get; set; }
}
