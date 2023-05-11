using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WpfTemplateApp.Domain.Entities.Courses;
using WpfTemplateApp.Service.DTOs.Courses;
using WpfTemplateApp.Service.Exceptions;

namespace WpfTemplateApp.Service.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<CourseForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null);
    Task<CourseForViewDTO> GetAsync(Expression<Func<Course, bool>> expression);
    Task<CourseForCreateDTO> CreateAsync(CourseForCreateDTO courseForCreateDto);
    Task<bool> DeleteAsync(int id);
    Task<CourseForUpdateDTO> UpdateAsync(int id, CourseForUpdateDTO courseForUpdateDto);

}