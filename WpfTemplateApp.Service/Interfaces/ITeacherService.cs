using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WpfTemplateApp.Domain.Entities.Students;
using WpfTemplateApp.Domain.Entities.Teachers;
using WpfTemplateApp.Service.DTOs.Students;
using WpfTemplateApp.Service.DTOs.Teachers;
using WpfTemplateApp.Service.Exceptions;

namespace WpfTemplateApp.Service.Interfaces;

public interface ITeacherService
{
    Task<IEnumerable<TeacherForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Teacher, bool>> expression = null);
    Task<TeacherForViewDTO> GetAsync(Expression<Func<Teacher, bool>> expression);
    Task<TeacherForCreateDTO> CreateAsync(TeacherForCreateDTO teacherForCreateDto);
    Task<bool> DeleteAsync(int id);
    Task<TeacherForUpdateDTO> UpdateAsync(int id, TeacherForUpdateDTO teacherForUpdateDto);
}
