using Microsoft.EntityFrameworkCore;
using TasksManagerMVC.Models;

namespace TasksManagerMVC.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.ToTable("MVCTasks");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired();
            });
        }
    }
}