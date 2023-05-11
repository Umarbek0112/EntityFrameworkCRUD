using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WpfTemplateApp.Domain.Configurations;
using WpfTemplateApp.Service.DTOs.Configurations.StudentCourse;
using WpfTemplateApp.Service.Exceptions;

namespace WpfTemplateApp.Service.Interfaces.Configurations
{
    public interface IStudentCourseService
    {
        Task<IEnumerable<StudentCourseForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<StudentCourse, bool>> expression = null );
        Task<StudentCourseForViewDTO> GetAsync(Expression<Func<StudentCourse, bool>> expression = null);
        Task<StudentCourseForCreateUpdateDTO> CreateAsync(StudentCourseForCreateUpdateDTO studentCourseForCreate);
        Task<StudentCourseForCreateUpdateDTO> UpdateAsync(int id, StudentCourseForCreateUpdateDTO studentCourseForUpdate);
        Task<bool> DeleteAsync(int id);
    }
}
