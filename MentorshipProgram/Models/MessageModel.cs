using System.ComponentModel.DataAnnotations;

namespace MentorshipProgram.Models;

public class MessageModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string SenderEmail { get; set; }
    [Required]
    public string ReceiverEmail { get; set; }
    [Required]
    public string Body { get; set; }
    DateTime TimeSent { get; set; } = DateTime.Now;
}
