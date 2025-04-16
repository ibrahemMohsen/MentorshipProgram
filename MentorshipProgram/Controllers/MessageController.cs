using Microsoft.AspNetCore.Mvc;

namespace MentorshipProgram.Controllers;

public class MessageController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
