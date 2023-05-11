using Microsoft.EntityFrameworkCore;
using WpfTemplateApp.Domain.Configurations;
using WpfTemplateApp.Domain.Entities.Courses;
using WpfTemplateApp.Domain.Entities.Students;
using WpfTemplateApp.Domain.Entities.Teachers;

namespace WpfTemplateApp.Data.DbContexs;

public class WpfTemplateAppDbContex : DbContext
{
    public DbSet<Course> Courses { get; set; } 
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<TeacherCourse> TeacherCourses { get; set; }
    public DbSet<TeacherStudent> TeacherStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost; Port=5432; Username=postgres; password=7410; Database=WpfTemplateAppDb;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasIndex(x => x.Email)
            .IsUnique(true);

        modelBuilder.Entity<Teacher>()
            .HasIndex(x => x.Email)
            .IsUnique(true);


    }

    
        
}