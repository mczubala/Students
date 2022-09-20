using Microsoft.EntityFrameworkCore;
using Students.Entities;

namespace Students.DbContext
{
    public class StudentsInfoContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        
        public StudentsInfoContext(DbContextOptions<StudentsInfoContext> options): base (options)
        {
        
        }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         optionsBuilder.UseSqlite("Data Source=StudentsInfo.db");
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student("Adam", "Adamowicz")
                {
                    Id = 1,
                    Age = 22,
                    Gender = "male"
                },
                new Student("Basia", "Basiowicz")
                {
                    Id = 2,
                    Age = 33,
                    Gender = "female"
                }
            );
        }
    }
}