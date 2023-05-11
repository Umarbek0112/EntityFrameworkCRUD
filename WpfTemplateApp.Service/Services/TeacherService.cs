using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WpfTemplateApp.Data.IRepository;
using WpfTemplateApp.Data.Repository;
using WpfTemplateApp.Domain.Entities.Teachers;
using WpfTemplateApp.Service.DTOs.Teachers;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Extensions;
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Mappers;

namespace WpfTemplateApp.Service.Services;

public class TeacherService : ITeacherService
{
    protected readonly IGenericRepository<Teacher> teacherRepositoriy;
    protected readonly IMapper mappers;
    
    public TeacherService()
    {
        teacherRepositoriy = new GenericRepository<Teacher>();
        mappers = new MapperConfiguration(cfg =>
                cfg.AddProfile<MappingProfile>())
            .CreateMapper();
    }
    
    public async Task<IEnumerable<TeacherForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Teacher, bool>> expression = null)
    {
        var teacher =  teacherRepositoriy.GetAll(expression, isTracking: false).ToPagedList(@params);
        return  mappers.Map<IEnumerable<TeacherForViewDTO>>(await teacher.ToListAsync());
    }

    public async Task<TeacherForViewDTO> GetAsync(Expression<Func<Teacher, bool>> expression)
    {
        var teacher = await teacherRepositoriy.GetAsync(expression, isTracking: false);
        if (teacher == null)
            throw new WpfExceptions("Teacher not found");
        return mappers.Map<TeacherForViewDTO>(teacher);
    }

    public async Task<TeacherForCreateDTO> CreateAsync(TeacherForCreateDTO teacherForCreateDTO)
    {
        var teacher = await teacherRepositoriy.GetAsync(x => x.Email == teacherForCreateDTO.Email);
        if (teacher != null)
            throw new WpfExceptions("Email mavjud");

        teacher = mappers.Map<Teacher>(teacherForCreateDTO);
        teacher.CreateAt = DateTime.UtcNow;
        teacher.UpdateAt = DateTime.UtcNow;
        await teacherRepositoriy.CreateAsync(teacher);
        await teacherRepositoriy.SaveChangesAsync();
         
         return mappers.Map<TeacherForCreateDTO>(teacher);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var teacher = await teacherRepositoriy.DeleteAsync(id);

        if (!teacher)
            throw new WpfExceptions("Studnt Deleted not found");
        
        await teacherRepositoriy.SaveChangesAsync();
        return true;
    }

    public async Task<TeacherForUpdateDTO> UpdateAsync(int id, TeacherForUpdateDTO teacherForUpdateDto)
    {
        var teacher = await teacherRepositoriy.GetAsync(x => x.Id == id);
        if (teacher == null)
            throw new WpfExceptions("Teacher not found");
        
        var _teacher = await teacherRepositoriy.GetAsync(x => x.Email == teacherForUpdateDto.Email && x.Id != id);
        if (_teacher != null)
            throw new WpfExceptions("Email not found");
        
        mappers.Map(teacherForUpdateDto, teacher);
        teacher.UpdateAt = DateTime.UtcNow;
        teacherRepositoriy.Update(teacher);
        await teacherRepositoriy.SaveChangesAsync();

        return mappers.Map<TeacherForUpdateDTO>(teacher);
    }
}