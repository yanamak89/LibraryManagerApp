using LibraryManagerApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    // Налаштовуємо сервіси, включаючи DbContext
    public void ConfigureServices(IServiceCollection services)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables(); // Додавання змінних середовища

        var configuration = builder.Build();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                .Replace("{ENV_PASSWORD}", Environment.GetEnvironmentVariable("SQL_PASSWORD"))));

        services.AddControllersWithViews();
    }

    
    // Налаштовуємо middleware для обробки HTTP-запитів
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    

}