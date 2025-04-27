using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


    public DateTime TimeSent { get; set; } = DateTime.Now;

    [ForeignKey("Chat")]
    public int ChatId { get; set; }

    public virtual ChatModel Chat { get; set; }

}
