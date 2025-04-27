using MentorshipProgram.Data;
using MentorshipProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace MentorshipProgram.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _db { get; init; }
        public UserModel _user { get; set; }
        public UserController(ApplicationDbContext db)
        {
            _db = db;
            _user = null;
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
        public IActionResult CreateMentor(MentorModel Mentor)
        {
            Mentor.UserName = Mentor.User.UserName;
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

        public IActionResult CreateMentee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMentee(MenteeModel Mentee)
        {
            Mentee.UserName = Mentee.User.UserName;
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

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(UserModel User)
        {
            try
            {
                var user = _db.Users
                    .FirstOrDefault(u => u.UserName == User.UserName
                    && u.Password == User.Password);
                var user_mentor = _db.Mentors
                    .FirstOrDefault(m => m.UserName == User.UserName);
                if (user_mentor is not null)
                {

                }
                var user_mentee = _db.Mentees
                    .FirstOrDefault(m => m.UserName == User.UserName);
                if (user_mentee is not null)
                {

                }

                if (user is not null)
                {
                    HttpContext.Session.SetString("UserName", user.UserName);
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Speciality()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Speciality(string speciality)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            if (speciality == "Mentors")
            {
                
            }
            else if (speciality == "Mentees")
            {

            }
            else
            {
                return View("Speciality");
            }

            return View();
        }
    }
}
