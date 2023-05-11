using WpfTemplateApp.Domain.Entities.Courses;
using WpfTemplateApp.Domain.Entities.Students;


namespace WpfTemplateApp.Service.DTOs.Configurations.StudentCourse;

public class StudentCourseForViewDTO
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; } 
}