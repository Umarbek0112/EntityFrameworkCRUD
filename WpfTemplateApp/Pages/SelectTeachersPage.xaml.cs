using System.Windows;
using System.Windows.Controls;
using WpfTemplateApp.Controls;
using WpfTemplateApp.Service.Exceptions;
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Services;

namespace WpfTemplateApp.Pages
{
    /// <summary>
    /// Interaction logic for SelectTeachersPage.xaml
    /// </summary>
    public partial class SelectTeachersPage : Page
    {
        private readonly ITeacherService _service;
        public SelectTeachersPage()
        {
            _service = new TeacherService();
            InitializeComponent();
        }

        private async void PageLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            PaginationParams paginationParams = new PaginationParams();
            paginationParams.PageSize = 10;
            paginationParams.PageIndex = 0;

            TeacherControlofSet.Items.Clear();
            var teachers = await _service.GetAllAsync(paginationParams);

            foreach (var teacher in teachers)
            {
                TeacherControls Control = new TeacherControls();
                Control.TeacherId = teacher.Id;
                Control.UpdateBtn.CommandParameter = teacher.Id.ToString();
                Control.TextBlockUsername.Text = $"{teacher.FirstName} {teacher.Name}";
                Control.TextBlockEmail.Text = teacher.Email;
                Control.TextBlockPhone.Text = teacher.PhoneNumber;
                Control.TextBlockInfo.Text = teacher.Info;
                Control.UpdateBtn.Click += UpdateBtn_Click;

                TeacherControlofSet.Items.Add(Control);
            }
        }

        public async void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateTeacher updateUserPage = new UpdateTeacher()
            {
                TeacherId = int.Parse((sender as Button).CommandParameter.ToString()),
            };

            TeacherFrame.Content = updateUserPage;
        }
    }
}
