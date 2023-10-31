using Microsoft.EntityFrameworkCore;
using MBCM_PWA.Client.Shared;

namespace MBCM_PWA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            
            // Add services to the container
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MBCM_DbContext>(options =>
                options.UseSqlServer(connectionString));

           /* builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); //Times out after 30 minutes
            });*/


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("AllowSpecificOrigin"); // Add this line to enable CORS
            

            // Add this line to use session
            //app.UseSession();

            app.MapRazorPages();
            app.MapControllers();

            app.Map("/api", api =>
            {
                api.UseRouting();
                api.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
