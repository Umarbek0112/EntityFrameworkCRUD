using System.Collections.Generic;
using WpfTemplateApp.Domain.Commons;
using WpfTemplateApp.Domain.Entities.Courses;
using WpfTemplateApp.Domain.Entities.Students;

namespace WpfTemplateApp.Domain.Configurations;

public class StudentCourse : Auditable
{
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int CourseId { get; set; }
    public Course Courses { get; set; }
}