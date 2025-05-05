using System.ComponentModel.DataAnnotations;

namespace MentorshipProgram.DTOs;

public class SendMessageViewModel
{
    [Required]
    [EmailAddress]
    [Length(8, 100)]
    public string ReceiverEmail { get; set; }
    [Required]
    public string Body { get; set; }

}
