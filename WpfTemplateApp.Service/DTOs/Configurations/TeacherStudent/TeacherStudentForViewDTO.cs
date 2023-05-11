using WpfTemplateApp.Domain.Entities.Students;
using WpfTemplateApp.Domain.Entities.Teachers;

namespace WpfTemplateApp.Service.DTOs.Configurations.TeacherStudent
{
    public class TeacherStudentForViewDTO
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
