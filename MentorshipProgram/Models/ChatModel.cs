using System.ComponentModel.DataAnnotations;

namespace MentorshipProgram.Models;

public class ChatModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Participant1Email { get; set; }
    [Required]
    public string Participant2Email { get; set; }

    public virtual ICollection<MessageModel> Messages { get; set; } = new List<MessageModel>();
}
