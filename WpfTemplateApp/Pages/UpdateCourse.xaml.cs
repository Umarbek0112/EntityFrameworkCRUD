using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfTemplateApp.Domain.Enums;
using WpfTemplateApp.Service.DTOs.Courses;
using WpfTemplateApp.Service.Services;

namespace WpfTemplateApp.Pages
{
    /// <summary>
    /// Interaction logic for UpdateCourse.xaml
    /// </summary>
    public partial class UpdateCourse : Page
    {
        protected readonly CourseService _service;
        public UpdateCourse()
        {
            _service = new CourseService();
            InitializeComponent();
        }

        

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var course = await _service.GetAsync(x => x.Id == 8);
            Name.Text = course.Name;
            Money.Text = course.Price.ToString();
            Type.Text = course.Type.ToString();

        }

        private async void Button_Click_UpdateCourseAsync(object sender, RoutedEventArgs e)
        {
            CoursType courseType = (CoursType)Enum.Parse(typeof(CoursType), Type.Text);

            CourseForUpdateDTO coursee = new CourseForUpdateDTO
            {
                Name = Name.Text,
                Price = int.Parse(Money.Text),
                Type = courseType,
            };

            await _service.UpdateAsync(8, coursee);
        }

        
    }
}
