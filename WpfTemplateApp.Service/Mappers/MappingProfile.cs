using AutoMapper;
using WpfTemplateApp.Domain.Configurations;
using WpfTemplateApp.Domain.Entities.Courses;
using WpfTemplateApp.Domain.Entities.Students;
using WpfTemplateApp.Domain.Entities.Teachers;
using WpfTemplateApp.Service.DTOs.Configurations.StudentCourse;
using WpfTemplateApp.Service.DTOs.Configurations.TeacherCourse;
using WpfTemplateApp.Service.DTOs.Configurations.TeacherStudent;
using WpfTemplateApp.Service.DTOs.Courses;
using WpfTemplateApp.Service.DTOs.Students;
using WpfTemplateApp.Service.DTOs.Teachers;

namespace WpfTemplateApp.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Course Mapper
        CreateMap<Course, CourseForCreateDTO>().ReverseMap();
        CreateMap<Course, CourseForUpdateDTO>().ReverseMap();
        CreateMap<Course, CourseForViewDTO>().ReverseMap();
        //Studnt Mappers
        CreateMap<Student, StudentForCreateDTO>().ReverseMap();
        CreateMap<Student, StudentForUpdateDTO>().ReverseMap();
        CreateMap<Student, StudentForViewDTO>().ReverseMap();
        //Teachers Mapper
        CreateMap<Teacher, TeacherForCreateDTO>().ReverseMap();
        CreateMap<Teacher, TeacherForUpdateDTO>().ReverseMap();
        CreateMap<Teacher, TeacherForViewDTO>().ReverseMap();
        //StudentCourse Mapper
        CreateMap<StudentCourse, StudentCourseForCreateUpdateDTO>().ReverseMap();
        CreateMap<StudentCourse, StudentCourseForViewDTO>().ReverseMap();
        //TeacherStudent Mapper
        CreateMap<TeacherStudent, TeacherStudentForCreateUpdateDTO>().ReverseMap();
        CreateMap<TeacherStudent, TeacherStudentForViewDTO>().ReverseMap();
        //TeacherCourse Mapper
        CreateMap<TeacherCourse, TeacherCourseForCreateUpdateDTO>().ReverseMap();
        CreateMap<TeacherCourse, TeacherCourseForViewDTO>().ReverseMap();

       
    }
}