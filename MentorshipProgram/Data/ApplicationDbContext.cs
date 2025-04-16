using MentorshipProgram.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorshipProgram.Data;
public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<UserModel> Users { get; set; } 
    public DbSet<MenteeModel> Mentees { get; set; }
    public DbSet<MentorModel> Mentors { get; set; }
    public DbSet<MessageModel> Messages { get; set; }

}
