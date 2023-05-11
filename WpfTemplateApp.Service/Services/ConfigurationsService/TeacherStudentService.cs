using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WpfTemplateApp.Data.IRepository;
using WpfTemplateApp.Data.Repository;
using WpfTemplateApp.Domain.Configurations;
using WpfTemplateApp.Domain.Entities.Students;
using WpfTemplateApp.Domain.Entities.Teachers;
using WpfTemplateApp.Service.DTOs.Configurations.TeacherStudent;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Extensions;
using WpfTemplateApp.Service.Interfaces.Configurations;
using WpfTemplateApp.Service.Mappers;

namespace WpfTemplateApp.Service.Services.ConfigurationsService
{
    public class TeacherStudentService : ITeacherStudentService
    {
        private readonly IGenericRepository<TeacherStudent> _teacherStudentRepostry;
        private readonly IGenericRepository<Teacher> _teacher;
        private readonly IGenericRepository<Student> _student;
        private readonly IMapper mapper;

        public TeacherStudentService()
        {
            _teacherStudentRepostry = new GenericRepository<TeacherStudent>();
            _teacher = new GenericRepository<Teacher>();
            _student = new GenericRepository<Student>();
            mapper = new MapperConfiguration(
                cfg => cfg.AddProfile<MappingProfile>())
                .CreateMapper();
        }

        public async Task<TeacherStudentForCreateUpdateDTO> CreateAsync(TeacherStudentForCreateUpdateDTO teacherStudentForCreate)
        {
            var teacherId = await _teacher.GetAsync(x => x.Id == teacherStudentForCreate.TeacherId);
            if (teacherId == null)
                throw new WpfExceptions("Studnt Not found");

            var CourseId = await _student.GetAsync(x => x.Id == teacherStudentForCreate.StudentId);
            if (CourseId == null)
                throw new WpfExceptions("Course not found");

            var courseStudentIds = await _teacherStudentRepostry.GetAsync(x => x.StudentId == teacherStudentForCreate.StudentId && x.TeacherId == teacherStudentForCreate.TeacherId);
            if (courseStudentIds != null)
                throw new WpfExceptions("This cours is available to studnt");

            var studntCourseMapp = mapper.Map<TeacherStudent>(teacherStudentForCreate);
            studntCourseMapp.CreateAt = DateTime.UtcNow;
            studntCourseMapp.UpdateAt = DateTime.UtcNow;
            await _teacherStudentRepostry.CreateAsync(studntCourseMapp);
            await _teacherStudentRepostry.SaveChangesAsync();

            return teacherStudentForCreate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var studntCoure = await _teacherStudentRepostry.DeleteAsync(id);
            if (!studntCoure)
                throw new WpfExceptions("Not found");

            await _teacherStudentRepostry.SaveChangesAsync();
            return true;
        }
        
        public async Task<IEnumerable<TeacherStudentForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<TeacherStudent, bool>> expression = null)
        {
            var TeacherStudent = _teacherStudentRepostry.GetAll(expression, false).ToPagedList(@params);
            if (TeacherStudent == null)
                throw new WpfExceptions("Techer not found");

            return mapper.Map<IEnumerable<TeacherStudentForViewDTO>>(await TeacherStudent.ToListAsync());
        }

        public async Task<TeacherStudentForViewDTO> GetAsync(Expression<Func<TeacherStudent, bool>> expression = null)
        {
            var TeacherStudent = await _teacherStudentRepostry.GetAsync(expression, false);
            if (TeacherStudent == null)
                throw new WpfExceptions("Teacher notfound");

            return mapper.Map<TeacherStudentForViewDTO>(TeacherStudent);
        }



        public async Task<TeacherStudentForCreateUpdateDTO> UpdateAsync(int id, TeacherStudentForCreateUpdateDTO TeacherStudentForCreate)
        {
            var TeacherStudentId = await _teacherStudentRepostry.GetAsync(x => x.Id == id);
            if (TeacherStudentId == null)
                throw new WpfExceptions(" not fount");

            var teacherId = await _teacher.GetAsync(x => x.Id == TeacherStudentForCreate.TeacherId);
            if (teacherId == null)
                throw new WpfExceptions("Studnt Not found");

            var CourseId = await _student.GetAsync(x => x.Id == TeacherStudentForCreate.StudentId);
            if (CourseId == null)
                throw new WpfExceptions("Course not found");

            var courseStudentIds = _teacherStudentRepostry.GetAsync(x => x.StudentId == TeacherStudentForCreate.StudentId && x.TeacherId == TeacherStudentForCreate.TeacherId);
            if (courseStudentIds != null)
                throw new WpfExceptions("This cours is available to studnt");

            mapper.Map(TeacherStudentId, TeacherStudentForCreate);
            TeacherStudentId.UpdateAt = DateTime.UtcNow;
            _teacherStudentRepostry.Update(TeacherStudentId);
            await _teacherStudentRepostry.SaveChangesAsync();

            return TeacherStudentForCreate;
        }
    }
}
