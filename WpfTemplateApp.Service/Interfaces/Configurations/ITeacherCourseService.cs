using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WpfTemplateApp.Domain.Configurations;
using WpfTemplateApp.Service.DTOs.Configurations.StudentCourse;
using WpfTemplateApp.Service.DTOs.Configurations.TeacherCourse;
using WpfTemplateApp.Service.DTOs.Configurations.TeacherStudent;
using WpfTemplateApp.Service.Exceptions;

namespace WpfTemplateApp.Service.Interfaces.Configurations
{
    public interface ITeacherCourseService
    {
        Task<IEnumerable<TeacherCourseForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<TeacherCourse, bool>> expression = null);
        Task<TeacherCourseForViewDTO> GetAsync(Expression<Func<TeacherCourse, bool>> expression = null);
        Task<TeacherCourseForCreateUpdateDTO> CreateAsync(TeacherCourseForCreateUpdateDTO teacherStudentForCreate);
        Task<TeacherCourseForCreateUpdateDTO> UpdateAsync(int id, TeacherCourseForCreateUpdateDTO teacherStudentForUpdare);
        Task<bool> DeleteAsync(int id);
    }
}
