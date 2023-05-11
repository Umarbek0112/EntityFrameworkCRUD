using System.Collections.Generic;
using WpfTemplateApp.Domain.Commons;
using WpfTemplateApp.Domain.Configurations;
using WpfTemplateApp.Domain.Enums;

namespace WpfTemplateApp.Domain.Entities.Courses;

public class Course : Auditable
{
    public string Name { get; set; }
    public int Price { get; set; }
    public CoursType Type { get; set; }
}