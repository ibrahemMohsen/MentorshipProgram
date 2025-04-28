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
    public DbSet<ChatModel> Chats { get; set; }
    public DbSet<UserDetailsModel>UserDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatModel>()
            .HasMany(c => c.Messages)
            .WithOne(m => m.Chat)
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
