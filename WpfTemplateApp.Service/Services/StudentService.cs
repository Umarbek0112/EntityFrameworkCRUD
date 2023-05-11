using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WpfTemplateApp.Data.IRepository;
using WpfTemplateApp.Data.Repository;
using WpfTemplateApp.Domain.Entities.Students;
using WpfTemplateApp.Service.DTOs.Students;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Extensions;
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Mappers;

namespace WpfTemplateApp.Service.Services;

public class StudentService : IStudentService
{
    protected readonly IGenericRepository<Student> studentRepositoriy;
    protected readonly IMapper mappers;
    
    public StudentService()
    {
        studentRepositoriy = new GenericRepository<Student>();
        mappers = new MapperConfiguration(cfg =>
                cfg.AddProfile<MappingProfile>())
                .CreateMapper();
    }

    public async Task<IEnumerable<StudentForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Student, bool>> expression = null)
    {
        var student =  studentRepositoriy.GetAll(expression, isTracking: false).ToPagedList(@params);
        return  mappers.Map<IEnumerable<StudentForViewDTO>>(await student.ToListAsync());
    }

    public async Task<StudentForViewDTO> GetAsync(Expression<Func<Student, bool>> expression)
    {
        var student = await studentRepositoriy.GetAsync(expression, isTracking: false);
        if (student == null)
            throw new WpfExceptions("Student not found");
        return mappers.Map<StudentForViewDTO>(student);
    }

    public async Task<StudentForViewDTO> CreateAsync(StudentForCreateDTO studentForCreateDTO)
    {
        var student = await studentRepositoriy.GetAsync(x => x.Email == studentForCreateDTO.Email);
        if (student != null)
            throw new WpfExceptions("Email mavjud");

        student = mappers.Map<Student>(studentForCreateDTO);
        student.CreateAt = DateTime.UtcNow;
        student.UpdateAt = DateTime.UtcNow;
        await studentRepositoriy.CreateAsync(student);
        await studentRepositoriy.SaveChangesAsync();
         
        return mappers.Map<StudentForViewDTO>(student);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var studnt = await studentRepositoriy.DeleteAsync(id);
        if (!studnt)
            throw new WpfExceptions("Studnt Deleted not found");
        
        await studentRepositoriy.SaveChangesAsync();
        return true;
    }

    public async Task<StudentForUpdateDTO> UpdateAsync(int id, StudentForUpdateDTO studentForUpdateDto)
    {
        var studnt = await studentRepositoriy.GetAsync(x => x.Id == id);
        if (studnt == null)
            throw new WpfExceptions("Studnt not found");
        
        var _studnt = await studentRepositoriy.GetAsync(x => x.Email == studentForUpdateDto.Email && x.Id != id);
        if (_studnt != null)
            throw new WpfExceptions("Email not found");
        
        mappers.Map(studentForUpdateDto, studnt);
        studnt.UpdateAt = DateTime.UtcNow;
        studentRepositoriy.Update(studnt);
        await studentRepositoriy.SaveChangesAsync();

        return mappers.Map<StudentForUpdateDTO>(studnt);
    }
}