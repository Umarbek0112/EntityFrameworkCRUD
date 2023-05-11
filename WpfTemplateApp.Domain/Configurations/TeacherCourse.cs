using System.Collections.Generic;
using WpfTemplateApp.Domain.Commons;
using WpfTemplateApp.Domain.Entities.Courses;
using WpfTemplateApp.Domain.Entities.Teachers;

namespace WpfTemplateApp.Domain.Configurations;

public class TeacherCourse : Auditable
{
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    
    public int CourseId { get; set; }
    public Course Courses { get; set; }
    
}