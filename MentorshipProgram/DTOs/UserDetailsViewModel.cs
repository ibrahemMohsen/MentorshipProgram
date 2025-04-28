using MentorshipProgram.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MentorshipProgram.DTOs;

public class UserDetailsViewModel
{
    [Required]
    [MaxLength(255)]
    public string FileName { get; set; }

    [Required]
    [MaxLength(100)]
    public string ContentType { get; set; }
    [NotMapped]
    [DisplayName("Upload Image")]
    public IFormFile ImageFile { get; set; }
}
