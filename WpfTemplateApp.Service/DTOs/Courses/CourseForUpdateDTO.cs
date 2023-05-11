using WpfTemplateApp.Domain.Enums;

namespace WpfTemplateApp.Service.DTOs.Courses;

public class CourseForUpdateDTO
{
    public string Name { get; set; }
    public int Price { get; set; }
    public CoursType Type { get; set; } 
}