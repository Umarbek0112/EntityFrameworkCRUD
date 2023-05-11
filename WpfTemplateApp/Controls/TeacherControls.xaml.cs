    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfTemplateApp.Service.Interfaces;
using WpfTemplateApp.Service.Services;

namespace WpfTemplateApp.Controls
{
    /// <summary>
    /// Interaction logic for TeacherControls.xaml
    /// </summary>
    public partial class TeacherControls : UserControl
    {
        private readonly ITeacherService _teacherService;
        public int TeacherId { get; set; }
        public TeacherControls()
        {
            _teacherService = new TeacherService();
            InitializeComponent();
        }

        private async void Button_Click_Delette(object sender, RoutedEventArgs e)
        {
            await _teacherService.DeleteAsync(TeacherId);
            var nextAction = MessageBox.Show("O'chirildi");
        }
    }
}
