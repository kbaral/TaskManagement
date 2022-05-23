using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Entities;
using static TaskManagement.Data.Entities.PriorityLevel;
using static TaskManagement.Data.Entities.StatusLevel;

namespace TaskManagement.Data
{  

    public class TaskContext : DbContext
    {
        
       // protected readonly IConfiguration Configuration;
        public TaskContext(DbContextOptions options) : base(options)
        {
           // Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // connect to sql server with connection string from app settings
            // optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tasks>()
                .HasData(new Tasks()
                {
                    Id = 1,
                    Name = "First Seed",
                    Description = "First description of seed",
                    DueDate = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(30),
                    Priority = Priority.Low,
                    Status = Status.InProgress
                });
            //modelBuilder.Entity<PriorityLevel>()
            //    .ToTable("Priorities");
            //modelBuilder.Entity<StatusLevel>()
            //    .ToTable("Statuses");
        }
        public DbSet<Tasks> Tasks { get; set; }

        // TODO : Establish relationship with them to restrict bad data
        //public DbSet<PriorityLevel> Priorities { get; set; }
        //public DbSet<StatusLevel> Statuses { get; set; }
    }

    
}
