using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorshipProgram.Models;
public class UserDetailsModel
{
    [Key, ForeignKey(nameof(User))]
    [EmailAddress]
    [Length(8, 100)]
    public string UserName { get; set; }
    public UserModel User { get; set; }

    [Required]
    [MaxLength(255)]
    public string FileName { get; set; }

    [Required]
    [MaxLength(100)]
    public string ContentType { get; set; }
    [HiddenInput]
    public string ImageBase64 { get; set; }
    [NotMapped]
    [DisplayName("Upload Image")]
    public IFormFile ImageFile { get; set; }
}
