using System.Collections.Generic;
using WpfTemplateApp.Domain.Commons;
using WpfTemplateApp.Domain.Entities.Students;
using WpfTemplateApp.Domain.Entities.Teachers;

namespace WpfTemplateApp.Domain.Configurations;

public class TeacherStudent : Auditable
{
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    
    public int StudentId { get; set; }
    public Student Student { get; set; }
}