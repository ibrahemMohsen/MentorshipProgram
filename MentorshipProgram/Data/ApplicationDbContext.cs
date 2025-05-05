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
        
        modelBuilder.Entity<MentorModel>()
            .Navigation(m => m.User)
            .AutoInclude();



        //
        // 1. Cascade‑delete for Mentee, Mentor, UserDetails → User
        modelBuilder.Entity<MenteeModel>()
            .HasOne(m => m.User)
            .WithOne()
            .HasForeignKey<MenteeModel>(m => m.UserName)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MentorModel>()
            .HasOne(m => m.User)
            .WithOne()
            .HasForeignKey<MentorModel>(m => m.UserName)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserDetailsModel>()
            .HasOne(d => d.User)
            .WithOne()
            .HasForeignKey<UserDetailsModel>(d => d.UserName)
            .OnDelete(DeleteBehavior.Cascade);

        // 2. Message.SenderEmail & ReceiverEmail → User.UserName
        modelBuilder.Entity<MessageModel>()
            .HasOne<UserModel>()
            .WithMany()
            .HasForeignKey(m => m.SenderEmail);

        modelBuilder.Entity<MessageModel>()
            .HasOne<UserModel>()
            .WithMany()
            .HasForeignKey(m => m.ReceiverEmail);

        // 3. Chat.Participant1Email & Participant2Email → User.UserName
        modelBuilder.Entity<ChatModel>()
            .HasOne<UserModel>()
            .WithMany()
            .HasForeignKey(c => c.Participant1Email);

        modelBuilder.Entity<ChatModel>()
            .HasOne<UserModel>()
            .WithMany()
            .HasForeignKey(c => c.Participant2Email);
    }

}
