using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WpfTemplateApp.Data.IRepository;
using WpfTemplateApp.Data.Repository;
using WpfTemplateApp.Domain.Entities.Courses;
using WpfTemplateApp.Service.DTOs.Courses;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Extensions;
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Mappers;

namespace WpfTemplateApp.Service.Services;

public class CourseService : ICourseService
{
    protected readonly IGenericRepository<Course> courseRepositoriy;
    protected readonly IMapper mappers;
    
    public CourseService()
    {
        courseRepositoriy = new GenericRepository<Course>();
        mappers = new MapperConfiguration(cfg =>
                cfg.AddProfile<MappingProfile>())
                .CreateMapper();
    }

    public async Task<IEnumerable<CourseForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null)
    {
        var student =  courseRepositoriy.GetAll(expression, isTracking: false).ToPagedList(@params);
        return  mappers.Map<IEnumerable<CourseForViewDTO>>(await student.ToListAsync());
    }

    public async Task<CourseForViewDTO> GetAsync(Expression<Func<Course, bool>> expression)
    {
        var student = await courseRepositoriy.GetAsync(expression, isTracking: false);
        if (student == null)
            throw new WpfExceptions("Student not found");
        return mappers.Map<CourseForViewDTO>(student);
    }

    public async Task<CourseForCreateDTO> CreateAsync(CourseForCreateDTO studentForCreateDTO)
    {     
        var course = mappers.Map<Course>(studentForCreateDTO);
        course.CreateAt = DateTime.UtcNow;
        course.UpdateAt = DateTime.UtcNow;
        await courseRepositoriy.CreateAsync(course);
        await courseRepositoriy.SaveChangesAsync();

        return mappers.Map<CourseForCreateDTO>(course);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var course = await courseRepositoriy.DeleteAsync(id);

        if (!course)
            throw new WpfExceptions("course Deleted not found");
        
        await courseRepositoriy.SaveChangesAsync();
        return true;
    }

    public async Task<CourseForUpdateDTO> UpdateAsync(int id, CourseForUpdateDTO courseForUpdateDto)
    {
        var course = await courseRepositoriy.GetAsync(x => x.Id == id);
        if (course == null)
            throw new WpfExceptions("course not found");

        mappers.Map(courseForUpdateDto, course);
        course.UpdateAt = DateTime.UtcNow;
        var student = courseRepositoriy.Update(course);
        await courseRepositoriy.SaveChangesAsync();

        return mappers.Map<CourseForUpdateDTO>(student);
    }
}