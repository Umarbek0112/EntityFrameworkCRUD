using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WpfTemplateApp.Domain.Entities.Students;
using WpfTemplateApp.Service.DTOs.Students;
using WpfTemplateApp.Service.Exceptions;

namespace WpfTemplateApp.Service.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<StudentForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Student, bool>> expression = null);
    Task<StudentForViewDTO> GetAsync(Expression<Func<Student, bool>> expression);
    Task<StudentForViewDTO> CreateAsync(StudentForCreateDTO studentForCreateDto);
    Task<bool> DeleteAsync(int id);
    Task<StudentForUpdateDTO> UpdateAsync(int id, StudentForUpdateDTO studentForUpdateDto);
}