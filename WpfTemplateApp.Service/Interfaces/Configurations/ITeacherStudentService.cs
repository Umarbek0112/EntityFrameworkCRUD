using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WpfTemplateApp.Domain.Configurations;
using WpfTemplateApp.Service.DTOs.Configurations.TeacherStudent;
using WpfTemplateApp.Service.Exceptions;

namespace WpfTemplateApp.Service.Interfaces.Configurations
{
    public interface ITeacherStudentService
    {
        Task<IEnumerable<TeacherStudentForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<TeacherStudent, bool>> expression = null);
        Task<TeacherStudentForViewDTO> GetAsync(Expression<Func<TeacherStudent, bool>> expression = null);
        Task<TeacherStudentForCreateUpdateDTO> CreateAsync(TeacherStudentForCreateUpdateDTO teacherStudentForCreate );
        Task<TeacherStudentForCreateUpdateDTO> UpdateAsync(int id, TeacherStudentForCreateUpdateDTO teacherStudentForUpdate);
        Task<bool> DeleteAsync(int id);
    }
}
