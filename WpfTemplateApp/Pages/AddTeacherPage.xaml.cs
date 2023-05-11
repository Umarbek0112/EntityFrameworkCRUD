using System.Windows;
using System.Windows.Controls;
using WpfTemplateApp.Service.DTOs.Configurations.TeacherCourse;
using WpfTemplateApp.Service.DTOs.Teachers;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Interfaces.Configurations;
using WpfTemplateApp.Service.Services;
using WpfTemplateApp.Service.Services.ConfigurationsService;

namespace WpfTemplateApp.Pages
{
    /// <summary>
    /// Interaction logic for AddTeacherPages.xaml
    /// </summary>
    public partial class AddTeacherPages : Page
    {
        private ITeacherService _teacherService;
        private ICourseService _courseService;
        private ITeacherCourseService _teacherCourseService;

        public AddTeacherPages()
        {
            _teacherService = new TeacherService();
            _courseService = new CourseService();
            _teacherCourseService = new TeacherCourseService();
            InitializeComponent();
        }

        private async void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {            
            TeacherForCreateDTO teacher = new TeacherForCreateDTO
            {
                Name = Name.Text,
                FirstName = FirstName.Text,
                Email = Email.Text,
                PhoneNumber = Phone.Text,
                Info = Info.Text,
            };
           await _teacherService.CreateAsync(teacher);

           var _teacher = await _teacherService.GetAsync(x => x.Email ==  Email.Text);
            ComboBoxItem selectedItem = (ComboBoxItem)ComboxCourse.SelectedItem;
            TeacherCourseForCreateUpdateDTO teacherCourse = new TeacherCourseForCreateUpdateDTO
            {
                TeacherId = _teacher.Id,
                CourseId = int.Parse(selectedItem.Tag.ToString())
            };
           await _teacherCourseService.CreateAsync(teacherCourse);

        }

        private async void window_LoadedAsync(object sender, RoutedEventArgs e)
        {           
            PaginationParams paginationParams = new PaginationParams();
            paginationParams.PageSize = 0;
            paginationParams.PageIndex = 0;                 
            foreach (var item in await _courseService.GetAllAsync(paginationParams))
            {
                ComboBoxItem combox = new ComboBoxItem()
                {
                    Content = $"{item.Name} {item.Type} ",
                    Tag = item.Id.ToString()
                };
                ComboxCourse.Items.Add(combox);
                
            }            
        }
    }
}
