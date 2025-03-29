using MentorshipProgram.Data;
using MentorshipProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace MentorshipProgram.Controllers;

public class CategoryController : Controller
{
    private ApplicationDbContext _db { get; init; }
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        IEnumerable<Category>? objCategoryList = _db.Categories;
        return View(objCategoryList);
    }

}
