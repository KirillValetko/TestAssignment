using System.Windows.Controls;

namespace TestAssignment.WPF.Views
{
    public partial class FirstTask : UserControl
    {
        public FirstTask()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ExportButton.IsEnabled = false;
        }
    }
}
