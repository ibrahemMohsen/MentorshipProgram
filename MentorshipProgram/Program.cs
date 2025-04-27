using MentorshipProgram.Data;
using Microsoft.EntityFrameworkCore;

namespace MentorshipProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            // Comment if Poor Performance is encoutered
            //builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


            // 1️⃣ Register an in-memory cache to back session storage
            builder.Services.AddDistributedMemoryCache();

            // 2️⃣ Register session services and configure options
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);  // session expires after 30 min of inactivity
                options.Cookie.HttpOnly = true;                   // client-side scripts can’t access the cookie
                options.Cookie.IsEssential = true;                // sent even if user hasn’t consented to non-essential cookies
            });



            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
