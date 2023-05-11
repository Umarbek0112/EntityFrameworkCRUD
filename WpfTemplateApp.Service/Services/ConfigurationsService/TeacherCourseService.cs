using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WpfTemplateApp.Data.IRepository;
using WpfTemplateApp.Data.Repository;
using WpfTemplateApp.Domain.Configurations;
using WpfTemplateApp.Domain.Entities.Courses;
using WpfTemplateApp.Domain.Entities.Teachers;
using WpfTemplateApp.Service.DTOs.Configurations.TeacherCourse;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Extensions;
using WpfTemplateApp.Service.Interfaces.Configurations;
using WpfTemplateApp.Service.Mappers;

namespace WpfTemplateApp.Service.Services.ConfigurationsService
{
    public class TeacherCourseService : ITeacherCourseService
    {
        private readonly IGenericRepository<TeacherCourse> _teacherCourseRepostry;
        private readonly IGenericRepository<Teacher> _teacher;
        private readonly IGenericRepository<Course> _course;
        private readonly IMapper mapper;

        public TeacherCourseService()
        {
            _teacherCourseRepostry = new GenericRepository<TeacherCourse>();
            _teacher = new GenericRepository<Teacher>();
            _course = new GenericRepository<Course>();
            mapper = new MapperConfiguration(
                cfg => cfg.AddProfile<MappingProfile>())
                .CreateMapper();
        }


        public async Task<TeacherCourseForCreateUpdateDTO> CreateAsync(TeacherCourseForCreateUpdateDTO teacherCourseForCreate)
        {
            var teacherId = await _teacher.GetAsync(x => x.Id == teacherCourseForCreate.TeacherId);
            if (teacherId == null)
                throw new WpfExceptions("Studnt Not found");

            var CourseId = await _course.GetAsync(x => x.Id == teacherCourseForCreate.CourseId);
            if (CourseId == null)
                throw new WpfExceptions("Course not found");

            var courseStudentIds = await _teacherCourseRepostry.GetAsync(x => x.CourseId == teacherCourseForCreate.CourseId && x.TeacherId == teacherCourseForCreate.TeacherId);
            if (courseStudentIds != null)
                throw new WpfExceptions("This cours is available to studnt");

            var studntCourseMapp = mapper.Map<TeacherCourse>(teacherCourseForCreate);
            studntCourseMapp.CreateAt = DateTime.UtcNow;
            studntCourseMapp.UpdateAt = DateTime.UtcNow;
            await _teacherCourseRepostry.CreateAsync(studntCourseMapp);
            await _teacherCourseRepostry.SaveChangesAsync();

            return teacherCourseForCreate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var studntCoure = await _teacherCourseRepostry.DeleteAsync(id);
            if (!studntCoure)
                throw new WpfExceptions("Not found");

            await _teacherCourseRepostry.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TeacherCourseForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<TeacherCourse, bool>> expression = null)
        {
            var teacherCourse = _teacherCourseRepostry.GetAll(expression, false).ToPagedList(@params);
            if (teacherCourse == null)
                throw new WpfExceptions("Techer not found");

            return mapper.Map<IEnumerable<TeacherCourseForViewDTO>>(await teacherCourse.ToListAsync());
        }

        public async Task<TeacherCourseForViewDTO> GetAsync(Expression<Func<TeacherCourse, bool>> expression = null)
        {
            var teacherCourse = await _teacherCourseRepostry.GetAsync(expression, false);
            if (teacherCourse == null)
                throw new WpfExceptions("Teacher notfound");

            return mapper.Map<TeacherCourseForViewDTO>(teacherCourse);
        }

       

        public async Task<TeacherCourseForCreateUpdateDTO> UpdateAsync(int id, TeacherCourseForCreateUpdateDTO teacherCourseForCreate)
        {
            var teacherCourseId = await _teacherCourseRepostry.GetAsync(x => x.Id == id);
            if (teacherCourseId == null)
                throw new WpfExceptions(" not fount");

            var teacherId = await _teacher.GetAsync(x => x.Id == teacherCourseForCreate.TeacherId);
            if (teacherId == null)
                throw new WpfExceptions("Studnt Not found");

            var CourseId = await _course.GetAsync(x => x.Id == teacherCourseForCreate.CourseId);
            if (CourseId == null)
                throw new WpfExceptions("Course not found");

            /*var courseStudentIds = _teacherCourseRepostry.GetAsync(x => x.CourseId == teacherCourseForCreate.CourseId && x => x.Teacher == teacherCourseForCreate.TicherId);
            if (courseStudentIds != null)
                throw new WpfExceptions("This cours is available to studnt");*/

            mapper.Map(teacherCourseId, teacherCourseForCreate);
            teacherCourseId.UpdateAt = DateTime.UtcNow;
             _teacherCourseRepostry.Update( teacherCourseId);
            await _teacherCourseRepostry.SaveChangesAsync();

            return teacherCourseForCreate;
        }


    }
}
