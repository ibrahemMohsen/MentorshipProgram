using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorshipProgram.Models;


public class MenteeModel
{
    [Key, ForeignKey(nameof(User))]
    [Required]
    [EmailAddress]
    [Length(8, 100)]
    public string UserName { get; set; }
    public UserModel User { get; set; }
    [Required]
    public string Interests { get; set; }
}
