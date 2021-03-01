using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaskListMVC.Models
{
    public partial class TaskListContext : DbContext
    {
        public TaskListContext()
        {
        }

        public TaskListContext(DbContextOptions<TaskListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ToDoItems> ToDoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TaskList;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItems>(entity =>
            {
                entity.Property(e => e.AssignedEmployee).HasMaxLength(25);

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.ItemDescription).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
