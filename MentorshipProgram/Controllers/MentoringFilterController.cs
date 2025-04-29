using MentorshipProgram.Data;
using MentorshipProgram.DTOs;
using MentorshipProgram.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MentorshipProgram.Controllers;
public class MentoringFilterController : Controller
{
    private ApplicationDbContext _db;
    public MentoringFilterController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(MentoringFilterViewModel filter)
    {
        if (ModelState.IsValid)
        {
            List<MentorModel>? qualifiedMentors = _db.Mentors
                .Where(m => m.YearsOfExperience >= filter.YearsOfExperience
                    && m.User.Field == filter.Field)
                .ToList();
            return View(nameof(QualifiedMentors), qualifiedMentors);
        }
        return View(nameof(Index));
    }
    [HttpGet]
    public IActionResult QualifiedMentors(List<MentorModel>? Mentors)
    {
        
        return View(Mentors);
    }
}
