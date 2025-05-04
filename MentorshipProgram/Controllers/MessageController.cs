using MentorshipProgram.Data;
using MentorshipProgram.DTOs;
using MentorshipProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorshipProgram.Controllers;

public class MessageController : Controller
{
    private ApplicationDbContext _db { get; init; }
    public MessageController(ApplicationDbContext db)
    {
        _db = db;
    }
    [HttpGet]
    public IActionResult Index(string ReceiverEmail)
    {
        string? userName = HttpContext.Session.GetString("UserName");
        ChatModel chat = GetOrCreateChat(userName, ReceiverEmail);

        var messages = _db.Messages
        .Where(m => m.ChatId == chat.Id)
        .ToList();
        chat.Messages = messages;

        return View(chat);
    }
    [HttpGet]
    public IActionResult SendMessage()
    {
        return View();
    }
    [HttpPost]
    public IActionResult SendMessage(SendMessageViewModel Message)
    {
        if (ModelState.IsValid)
        {
            string? userName = HttpContext.Session.GetString("UserName");
            ChatModel chat = GetOrCreateChat(userName, Message.ReceiverEmail);

            MessageModel message = new()
            {
                SenderEmail = userName,
                ReceiverEmail = Message.ReceiverEmail,
                Body = Message.Body,
                ChatId = chat.Id
            };
            _db.Messages.Add(message);
            _db.SaveChanges();
            return View();
        }
        else
        {
            return View();
        }
    }


    private ChatModel GetOrCreateChat(string Email1, string Email2)
    {
        int? id = _db.Chats
           .FirstOrDefault(u =>
           (u.Participant1Email == Email1 && u.Participant2Email == Email2)
           || (u.Participant1Email == Email2 && u.Participant2Email == Email1))
           ?.Id;
        ChatModel? chat;
        if (id is not null)
        {
            chat = _db.Chats.FirstOrDefault(c => c.Id == id);
        }
        else
        {
            chat = new()
            {
                Participant1Email = Email1,
                Participant2Email = Email2
            };
            _db.Chats.Add(chat);
            _db.SaveChanges();
        }
        return chat;
    }
}
