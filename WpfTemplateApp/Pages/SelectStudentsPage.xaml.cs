using System.Windows;
using System.Windows.Controls;
using WpfTemplateApp.Controls;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Services;

namespace WpfTemplateApp.Pages
{
    /// <summary>
    /// Interaction logic for SelectStudentsPage.xaml
    /// </summary>
    public partial class SelectStudentsPage : Page
    {
        private readonly IStudentService _studentService;
        public SelectStudentsPage()
        {
            _studentService = new StudentService();
            InitializeComponent();
        }

        private async void PageLoaded(object sender, RoutedEventArgs e)
        {
            PaginationParams paginationParams = new PaginationParams();
            paginationParams.PageSize = 10;
            paginationParams.PageIndex = 0;

            StudentcontrolofSet.Items.Clear();
            var students = await _studentService.GetAllAsync(paginationParams); 

            foreach ( var student in students )
            {
                StudentControl Control = new StudentControl();
                Control.UserId = student.Id;
                Control.UpdateBtn.CommandParameter = student.Id.ToString();
                Control.TextBlockUsername.Text = $"{student.FirstName} {student.Name}";
                Control.TextBlockEmail.Text = student.Email;
                Control.TextBlockPhone.Text = student.PhoneNumber;
                Control.UpdateBtn.Click += UpdateBtn_Click;

                StudentcontrolofSet.Items.Add(Control);
            }            
        }
        public async void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateStudentPage updateUserPage = new UpdateStudentPage()
            {
                StudentId = int.Parse((sender as Button).CommandParameter.ToString()),
            };
            
            StudentFrame.Content = updateUserPage;
        }
    }
}
