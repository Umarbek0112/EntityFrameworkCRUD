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
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Services;

namespace WpfTemplateApp.Controls
{
    /// <summary>
    /// Interaction logic for StudentControl.xaml
    /// </summary>
    public partial class StudentControl : UserControl
    {
        private readonly IStudentService _studentService;
        public int UserId { get; set; }
        public StudentControl()
        {
            _studentService = new StudentService();
            InitializeComponent();
        }

        private async void Button_Click_Delette(object sender, RoutedEventArgs e)
        {
            await _studentService.DeleteAsync(UserId);
            var nextAction = MessageBox.Show("O'chirildi");

        }

    }
}
