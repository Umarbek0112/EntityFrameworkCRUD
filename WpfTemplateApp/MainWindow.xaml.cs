
using System.Windows;
using WpfTemplateApp.Pages;

namespace WpfTemplateApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            
            if (LeftPanel.ActualWidth == 200)
            {
                LeftPanel.Width = new GridLength(87);
            }
            else
                LeftPanel.Width = new GridLength(200);

        }

        private void Add_Course_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AddCoursePage();
        }

        private void Add_Teacher_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AddTeacherPages();
        }

        private void Add_Studnt_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AddStudntPage();
        }

        private void SelectStudents_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new SelectStudentsPage();
        }

        private void Register_Page(object sender, RoutedEventArgs e)
        {

        }

        private void SelectTeachers_Click(object sender, RoutedEventArgs e)
        {
            
            MainFrame.Content = new SelectTeachersPage();
        }

        private void SelectCourses_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new SelectCoursesPage();
        }

        
    }
}