using MentorshipProgram.Data;
using MentorshipProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _db.Add(category);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        return View(category);
    }

}
