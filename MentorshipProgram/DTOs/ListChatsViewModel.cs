using MentorshipProgram.Models;

namespace MentorshipProgram.DTOs
{
    public class ListChatsViewModel
    {

        public List<MessageModel> Messages { get; set; }
        public SendMessageViewModel SendMessage { get; set; }
    }
}
