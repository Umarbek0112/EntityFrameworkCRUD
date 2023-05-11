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
using WpfTemplateApp.Domain.Entities.Courses;
using WpfTemplateApp.Domain.Enums;
using WpfTemplateApp.Service.DTOs.Courses;
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Services;

namespace WpfTemplateApp.Pages
{
    /// <summary>
    /// Interaction logic for AddCoursePage.xaml
    /// </summary>
    public partial class AddCoursePage : Page
    {
        private ICourseService service;
        public AddCoursePage()
        {
            service = new CourseService();

            InitializeComponent();
        }

        private async void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
            CoursType courseType = (CoursType)Enum.Parse(typeof(CoursType), Type.Text);

            CourseForCreateDTO course = new CourseForCreateDTO
            {
                Name = Name.Text,
                Price = int.Parse(Money.Text),
                Type = courseType,
            };

            await service.CreateAsync(course);
        }
    }
}
