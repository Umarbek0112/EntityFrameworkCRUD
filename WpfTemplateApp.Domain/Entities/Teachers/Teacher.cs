using System.ComponentModel.DataAnnotations;
using WpfTemplateApp.Domain.Commons;
using WpfTemplateApp.Domain.Entities.Courses;

namespace WpfTemplateApp.Domain.Entities.Teachers;

public class Teacher : Auditable
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Info { get; set; }
}
