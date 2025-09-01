using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PustokApp.Data;
using PustokApp.Profiles;
using PustokApp.Services;

namespace PustokApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<PustokDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddAutoMapper(opt => { }, typeof(MapperProfile).Assembly);
            builder.Services.AddScoped<LayoutService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
  );

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
