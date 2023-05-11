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
using WpfTemplateApp.Service.DTOs.Teachers;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Interfaces.Configurations;
using WpfTemplateApp.Service.Services;
using WpfTemplateApp.Service.Services.ConfigurationsService;

namespace WpfTemplateApp.Pages
{
    /// <summary>
    /// Interaction logic for UpdateTeacher.xaml
    /// </summary>
    public partial class UpdateTeacher : Page
    {
        public int TeacherId { get; set; }
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;

        public UpdateTeacher()
        {
            _teacherService = new TeacherService();
            _courseService = new CourseService();   

            InitializeComponent();
        }

        private async void LoadPage(object sender, RoutedEventArgs e)
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

            var teacher = await _teacherService.GetAsync(x => x.Id == TeacherId);

              Name.Text = teacher.Name;
              FirstName.Text = teacher.FirstName;
              Email.Text = teacher.Email;
              Phone.Text = teacher.PhoneNumber;
              Info.Text = teacher.Info;            
        }

        private async void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            TeacherForUpdateDTO teacher = new TeacherForUpdateDTO
            {
                Name = Name.Text,
                FirstName = FirstName.Text,
                Email = Email.Text,
                PhoneNumber = Phone.Text,
                Info = Info.Text,
            };
            await _teacherService.UpdateAsync(TeacherId, teacher);

            NavigationService.Navigate(new SelectTeachersPage());
        }
    }
}
