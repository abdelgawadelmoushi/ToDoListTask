using Microsoft.EntityFrameworkCore;

namespace ToDoListTask.Models.EntityConfigration
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet <ToDoList> toDoLists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ToDoTaskMVC;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ToDoEntityTypeConfiguration());

        }



    }
}
