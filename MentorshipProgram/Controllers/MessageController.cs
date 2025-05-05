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
    // All Messages in one chat (sender, receiver)
    [HttpGet]
    public IActionResult Index(int ChatId)
    {
        if (HttpContext.Session.GetString("UserName") is null)
        {
            return RedirectToAction(nameof(SignIn), nameof(User));
        }
        string? userName = HttpContext.Session.GetString("UserName");
        ChatModel chat = GetChat(ChatId);

        var messages = _db.Messages
        .Where(m => m.ChatId == chat.Id)
        .ToList();
        chat.Messages = messages;

        ChattingViewModel chatting = new()
        {
            Chat = chat,
            SendMessage = new SendMessageViewModel()
        };
        ViewBag.UserName = HttpContext.Session.GetString("UserName");


        return View(chatting);
    }
    [HttpGet]
    public IActionResult SendMessage()
    {
        return View();
    }
    // Send Message to a user
    [HttpPost]
    public IActionResult SendMessage(ChattingViewModel model)
    {
        SendMessageViewModel Message = model.SendMessage;
        if (HttpContext.Session.GetString("UserName") is null)
        {
            return RedirectToAction(nameof(SignIn), nameof(User));
        }
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
            return RedirectToAction("Index", new { ChatId = chat.Id }); ;
        }
        else
        {
            return View();
        }
    }


    [HttpPost]
    public IActionResult SendMessageNewChat(ListChatsViewModel model)
    {
        SendMessageViewModel Message = model.SendMessage;
        if (HttpContext.Session.GetString("UserName") is null)
        {
            return RedirectToAction(nameof(SignIn), nameof(User));
        }
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
            return RedirectToAction("Index", new { ChatId = chat.Id }); ;
        }
        else
        {
            return View();
        }
    }

    [HttpGet]
    public IActionResult ListChats()
    {
        if (HttpContext.Session.GetString("UserName") is null)
        {
            return RedirectToAction(nameof(SignIn), nameof(User));
        }
        string userName = HttpContext.Session.GetString("UserName");
        //List<ChatModel>? myChats = _db.Chats
        //    .Where(c => c.Participant1Email == userName || c.Participant2Email == userName)
        //    .ToList();
        //List<MessageModel> lastMessages;
        //foreach(ChatModel? chat in myChats)
        //{
        //    lastMessages.Add(chat.Messages.)
        //}

        var latestMessages = _db.Messages
            .Where(m => m.Chat.Participant1Email == userName || m.Chat.Participant2Email == userName)
            ?.GroupBy(m => m.ChatId)
            ?.Select(g => g.OrderByDescending(m => m.TimeSent).FirstOrDefault())
            ?.ToList();
        ListChatsViewModel Chats = new()
        {
            Messages = latestMessages,
            SendMessage = new SendMessageViewModel()
        };

        return View(Chats);
    }



    //helper
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
    private ChatModel? GetChat(int ChatId)
    {
        return _db.Chats.FirstOrDefault(c => c.Id == ChatId);
    }
}
