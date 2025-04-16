using MentorshipProgram.Data;
using MentorshipProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace MentorshipProgram.Controllers
{
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
        public IActionResult CreateMentor(MentorModel Mentor)
        {

            try
            {
                _db.Mentors.Add(Mentor);
                _db.SaveChanges();
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
            //try
            //{
            //    _db.Users.Add(User);
            //    _db.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    throw;
            //}
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
