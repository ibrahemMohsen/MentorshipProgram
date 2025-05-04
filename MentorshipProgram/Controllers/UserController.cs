using MentorshipProgram.Data;
using MentorshipProgram.DTOs;
using MentorshipProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace MentorshipProgram.Controllers;

public class UserController : Controller
{
    private ApplicationDbContext _db { get; init; }
    public UserController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult CreateMentor()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateMentor(CreateMentorViewModel mentor)
    {
        if (ModelState.IsValid)
        {
            MentorModel Mentor = new()
            {
                UserName = mentor.UserName,
                User=new()
                {
                    UserName = mentor.UserName,
                    Password = mentor.Password,
                    Name = mentor.Name,
                    Field = mentor.Field,
                },
                YearsOfExperience = mentor.YearsOfExperience,
            };
            try
            {
                _db.Mentors.Add(Mentor);
                _db.SaveChanges();
                HttpContext.Session.SetString("UserName", Mentor.UserName);
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

    public IActionResult CreateMentee()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateMentee(CreateMenteeViewModel mentee)
    {
        if (ModelState.IsValid)
        {
            MenteeModel Mentee = new()
            {
                User = new()
                {
                    Name = mentee.Name,
                    UserName = mentee.UserName,
                    Password = mentee.Password,
                    Field = mentee.Field
                },
                UserName = mentee.UserName,
                Interests = mentee.Interests
            };
            try
            {
                _db.Mentees.Add(Mentee);
                _db.SaveChanges();
                HttpContext.Session.SetString("UserName", Mentee.UserName);
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SignIn(SignInViewModel User)
    {
        if (ModelState.IsValid)
        {
            try
            {
                UserModel? user = _db.Users
                    .FirstOrDefault(u => u.UserName == User.UserName
                    && u.Password == User.Password);

                if (user is not null)
                {
                    HttpContext.Session.SetString("UserName", user.UserName);
                }
                else
                {
                    return RedirectToAction(nameof(SignIn));
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View();
        }
    }

   
}
