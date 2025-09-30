using Microsoft.EntityFrameworkCore;
using MVC02.Abdallah.BLL.Interfaces;
using MVC02.Abdallah.BLL.Reposatiries;
using MVC02.Abdallah.DAL.Data.Contexsts;
using MVC02.Abdallah.PL.Mapping;

namespace MVC02.Abdallah.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register your reposatory
            builder.Services.AddScoped<IDepartmentRepository, DepartmentReposatory>();


            builder.Services.AddScoped<IEmployeeReposatory, EmployeeReposatory>();
            // Register DbContext
            builder.Services.AddDbContext<CompantDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddScoped<IUnitOFWork, UnitOfWork>();

            builder.Services.AddAutoMapper(M=>M.AddProfile(new EmployeeProfile()));

            // Build the app
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
