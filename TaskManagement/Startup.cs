
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Services.Tasks;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddDbContext<TaskContext>(cfg =>
        {
            cfg.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        });
        
        services.AddTransient<ITasksService, TasksService>();

        //services.AddTransient<TaskSeeder>();
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
        // Configure the HTTP request pipeline.
        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}

