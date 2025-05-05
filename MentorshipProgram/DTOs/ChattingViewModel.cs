using MentorshipProgram.Models;

namespace MentorshipProgram.DTOs
{
    public class ChattingViewModel
    {
        public SendMessageViewModel SendMessage {get; set;}
        public ChatModel Chat { get; set; }
    }
}
