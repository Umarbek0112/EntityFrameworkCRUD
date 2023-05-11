using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTemplateApp.Domain.Entities.Teachers;
using WpfTemplateApp.Service.DTOs.Students;
using WpfTemplateApp.Service.DTOs.Teachers;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Services;

namespace WpfTemplateApp.Pages
{
    /// <summary>
    /// Interaction logic for UpdateStudentPage.xaml
    /// </summary>
    public partial class UpdateStudentPage : Page
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;
        public int StudentId { get; set; }
        public UpdateStudentPage()
        {            
            _studentService = new StudentService();
            _courseService = new CourseService();
            _teacherService = new TeacherService();
            InitializeComponent();
        }

        private async void PageLoaded(object sender, RoutedEventArgs e)
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
            foreach (var t in await _teacherService.GetAllAsync(paginationParams))
            {
                ComboBoxItem combox = new ComboBoxItem()
                {
                    Content = $"{t.Name} {t.FirstName} ",
                    Tag = t.Id.ToString()
                };
                Combox.Items.Add(combox);
            }

            var student = await _teacherService.GetAsync(x => x.Id == StudentId);
            Name.Text = student.Name;
            FirstName.Text = student.FirstName;
            Email.Text = student.Email;
            Phone.Text = student.PhoneNumber;            
        }

        private async void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            StudentForUpdateDTO student = new StudentForUpdateDTO
            {
                Name = Name.Text,
                FirstName = FirstName.Text,
                Email = Email.Text,
                PhoneNumber = Phone.Text
            };

            var update = await _studentService.UpdateAsync(StudentId, student);
                                    
            NavigationService.Navigate(new SelectStudentsPage());
        }
    }
}
