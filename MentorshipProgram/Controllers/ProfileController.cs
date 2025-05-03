using MentorshipProgram.Data;
using MentorshipProgram.DTOs;
using MentorshipProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentorshipProgram.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext _db { get; init; }
        public ProfileController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            UserDetailsModel details = _db.UserDetails.Find(HttpContext.Session.GetString("UserName"));
            return View(details);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Create([Bind("UserName, FileName, ContentType, ImageFile")]  UserDetailsViewModel userDetailsDTO)
        {
            if (ModelState.IsValid)
            {
                UserDetailsModel userDetails = new()
                {
                    UserName = HttpContext.Session.GetString("UserName"),
                    FileName = userDetailsDTO.FileName,
                    ContentType = userDetailsDTO.ContentType,
                    ImageFile = userDetailsDTO.ImageFile
                };
                using (var ms = new MemoryStream())
                {
                    userDetails.ImageFile.CopyTo(ms);
                    string base64 = Convert.ToBase64String(ms.ToArray());
                    base64 = "data:" + userDetails.ImageFile.ContentType + ";base64," + base64;
                    userDetails.ImageBase64 = base64;
                }

                try
                {
                    _db.UserDetails.Add(userDetails);
                    _db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            
            return View(nameof(Index));
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upload(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return Content("No file selected.");

        //    using var ms = new MemoryStream();
        //    file.CopyToAsync(ms);
        //    var image = new ImageFile
        //    {
        //        FileName = Path.GetFileName(file.FileName),
        //        ContentType = file.ContentType,
        //        Data = ms.ToArray()
        //    };

        //    UserDetailsModel userDetails = new()
        //    {
        //        UserName = HttpContext.Session.GetString("UserName"),
        //        ProfilePicture = image.Data,
        //    };

        //    _db.UserDetails.Add(userDetails);
        //     _db.SaveChanges();
        //    return View("Index");
        //}


        //public IActionResult Details(string UserName)
        //{
        //    var image =  _db.UserDetails.Find(UserName);
        //    if (image == null) return NotFound();
        //    return File(image.ProfilePicture, image.ContentType);
        //}
        //public IActionResult Image()
        //{
        //    return View(_db.UserDetails);
        //}
    }
}
