using WpfTemplateApp.Domain.Entities.Courses;
using WpfTemplateApp.Domain.Entities.Teachers;

namespace WpfTemplateApp.Service.DTOs.Configurations.TeacherCourse
{
    public class TeacherCourseForViewDTO
    {
        public int Id { get; set; }
        public int TicherId { get; set; }
        public Teacher Teacher { get; set; }

        public int CourseId { get; set; }
        public Course Courses { get; set; }
    }
}
