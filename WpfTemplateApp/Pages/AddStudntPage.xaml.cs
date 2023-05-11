
using System.Windows;
using System.Windows.Controls;
using WpfTemplateApp.Service.DTOs.Configurations.StudentCourse;
using WpfTemplateApp.Service.DTOs.Configurations.TeacherStudent;
using WpfTemplateApp.Service.DTOs.Students;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Interfaces.Configurations;
using WpfTemplateApp.Service.Services;
using WpfTemplateApp.Service.Services.Configurations;
using WpfTemplateApp.Service.Services.ConfigurationsService;

namespace WpfTemplateApp.Pages
{
    /// <summary>
    /// Interaction logic for AddStudntPage.xaml
    /// </summary>
    public partial class AddStudntPage : Page
    {        
        private readonly IStudentService studentService;
        private readonly ITeacherService teacherService;
        private readonly ICourseService courseService;
        private readonly IStudentCourseService studentCourseService;
        private readonly ITeacherStudentService studentTeacherService;
        public AddStudntPage()
        {
            studentService = new StudentService();
            teacherService = new TeacherService();
            courseService = new CourseService();
            studentCourseService = new StudntCourseService();
            studentTeacherService = new TeacherStudentService();

            InitializeComponent();  
        }

        private async void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            StudentForCreateDTO student = new StudentForCreateDTO()
            {
                Name = Name.Text,
                FirstName = FirstName.Text,
                Email = Email.Text,
                PhoneNumber = Phone.Text,
            };
            await studentService.CreateAsync(student);

            var studdent = await studentService.GetAsync(x => x.Email == Email.Text);
            ComboBoxItem selectedItem = (ComboBoxItem)ComboxCourse.SelectedItem;
            StudentCourseForCreateUpdateDTO createUpdateDTO = new StudentCourseForCreateUpdateDTO()
            {
                CourseId = int.Parse((string)selectedItem.Tag),
                StudentId = studdent.Id,
            };
            await studentCourseService.CreateAsync(createUpdateDTO);

            ComboBoxItem selectedItemCombox = (ComboBoxItem)Combox.SelectedItem;
            TeacherStudentForCreateUpdateDTO forCreateUpdateDTO = new TeacherStudentForCreateUpdateDTO()
            {
                StudentId = studdent.Id,
                TeacherId = int.Parse((string)selectedItemCombox.Tag)
            };
            await studentTeacherService.CreateAsync(forCreateUpdateDTO);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PaginationParams paginationParams = new PaginationParams();
            paginationParams.PageSize = 0;
            paginationParams.PageIndex = 0;

            foreach (var t in await teacherService.GetAllAsync(paginationParams))
            {
                ComboBoxItem combox = new ComboBoxItem()
                {
                    Content = $"{t.Name} {t.FirstName} ",
                    Tag = t.Id.ToString()
                };
                Combox.Items.Add(combox);
            }                            

            foreach (var item in await courseService.GetAllAsync(paginationParams))
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
