using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Data
{
    /// <summary>
    /// Database context for the Task Management System.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">Options for configuring the database context.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet for the Tasks table.
        /// </summary>
        public DbSet<TaskItem> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for the Users table.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Configures the model and relationships.
        /// </summary>
        /// <param name="modelBuilder">Model builder for configuring entities.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure TaskItem entity
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Title)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(t => t.Description)
                    .HasMaxLength(500);
                entity.HasOne(t => t.AssignedUser)
                    .WithMany()
                    .HasForeignKey(t => t.AssignedUserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.HasIndex(u => u.Email)
                    .IsUnique();
            });
        }
    }
}
