using System.ComponentModel.DataAnnotations;

namespace MentorshipProgram.DTOs;

public class SendMessageViewModel
{
    [Required]
    public string ReceiverEmail { get; set; }
    [Required]
    public string Body { get; set; }

}
