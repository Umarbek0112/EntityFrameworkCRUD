using System.ComponentModel.DataAnnotations;
using WpfTemplateApp.Domain.Commons;

namespace WpfTemplateApp.Domain.Entities.Students;

public class Student : Auditable
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
  

}
