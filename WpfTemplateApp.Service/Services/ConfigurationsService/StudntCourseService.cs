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
using WpfTemplateApp.Domain.Entities.Students;
using WpfTemplateApp.Service.DTOs.Configurations.StudentCourse;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Extensions;
using WpfTemplateApp.Service.Interfaces.Configurations;
using WpfTemplateApp.Service.Mappers;

namespace WpfTemplateApp.Service.Services.Configurations
{
    public class StudntCourseService : IStudentCourseService
    {
        private readonly IGenericRepository<StudentCourse> _studentCourseRepository;
        private readonly IGenericRepository<Student> _student;
        private readonly IGenericRepository<Course> _course;
        private readonly IMapper mapper;
        
        public StudntCourseService() 
        {
            _studentCourseRepository = new GenericRepository<StudentCourse>();
            _student = new GenericRepository<Student>();
            _course = new GenericRepository<Course>();
            mapper = new MapperConfiguration(
                cfg => cfg
                .AddProfile<MappingProfile>())
                .CreateMapper();
        }
        public async Task<StudentCourseForCreateUpdateDTO> CreateAsync(StudentCourseForCreateUpdateDTO studentCourseForCreate)
        {
            var studntId = await _student.GetAsync(x => x.Id == studentCourseForCreate.StudentId);
            if (studntId == null)
                throw new WpfExceptions("Studnt Not found");

            var CourseId = await _course.GetAsync(x => x.Id == studentCourseForCreate.CourseId);
            if (CourseId == null)
                throw new WpfExceptions("Course not found");

            var courseStudentIds = await _studentCourseRepository.GetAsync(x => x.CourseId == studentCourseForCreate.CourseId && x.StudentId == studentCourseForCreate.StudentId);
            if (courseStudentIds != null)
                throw new WpfExceptions("This cours is available to studnt");

            var studntCourseMapp = mapper.Map<StudentCourse>(studentCourseForCreate);
            studntCourseMapp.CreateAt = DateTime.UtcNow;
            studntCourseMapp.UpdateAt = DateTime.UtcNow;
            await _studentCourseRepository.CreateAsync(studntCourseMapp);
            await _studentCourseRepository.SaveChangesAsync();

            return studentCourseForCreate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var studntCoure = await _studentCourseRepository.DeleteAsync(id);
            if (!studntCoure)
                throw new WpfExceptions("Not found");

            await _studentCourseRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StudentCourseForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<StudentCourse, bool>> expression = null)
        {
            var studntCourses = _studentCourseRepository.GetAll(expression, isTracking: false).ToPagedList(@params);
            return mapper.Map<IEnumerable<StudentCourseForViewDTO>>( await studntCourses.ToListAsync());
        }

        public async Task<StudentCourseForViewDTO> GetAsync(Expression<Func<StudentCourse, bool>> expression = null)
        {
            var studntCourse = await _studentCourseRepository.GetAsync(expression, false);
            if (studntCourse == null)
                throw new WpfExceptions("StudntCours not found");

            return mapper.Map<StudentCourseForViewDTO>(studntCourse);
        }

        public async Task<StudentCourseForCreateUpdateDTO> UpdateAsync(int id, StudentCourseForCreateUpdateDTO studentCourseForUpdate)
        {
            var studntCours = await _studentCourseRepository.GetAsync(x => x.Id == id);
            if (studntCours == null)
                throw new WpfExceptions("not found");

            var studntId = await _student.GetAsync(x => x.Id == studentCourseForUpdate.StudentId);
            if (studntId == null)
                throw new WpfExceptions("Studnt Not found");

            var CourseId = await _course.GetAsync(x => x.Id == studentCourseForUpdate.CourseId);
            if (CourseId == null)
                throw new WpfExceptions("Course not found");

            var courseStudentIds = await _studentCourseRepository.GetAsync(x => x.CourseId == studentCourseForUpdate.CourseId && x.StudentId == studentCourseForUpdate.StudentId);
            if (courseStudentIds != null)
                throw new WpfExceptions("This cours is available to studnt");

            mapper.Map(studntCours, studentCourseForUpdate);
            studntCours.UpdateAt = DateTime.UtcNow;
            _studentCourseRepository.Update(studntCours);
            await _studentCourseRepository.SaveChangesAsync();

            return studentCourseForUpdate;
        }
    }
}
