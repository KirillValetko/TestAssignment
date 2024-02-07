using System.IO;
using System.Text;
using System.Windows;
using TestAssignment.Common.Constants;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using UserControl = System.Windows.Controls.UserControl;

namespace TestAssignment.WPF.Views
{
    public partial class SecondTask : UserControl
    {
        public SecondTask()
        {
            var files = Directory
                .GetFiles(ExcelConstants.DownloadDirectory)
                .ToList();
            var fileNames = new StringBuilder();

            foreach (var file in files)
            {
                fileNames.AppendLine(Path.GetFileName(file));
            }
            
            InitializeComponent();
            DownloadedFiles.Text = fileNames.ToString();
        }

        private void OpenDialogBtn_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = ExcelConstants.ExcelFilter
            };
            
            var result = fileDialog.ShowDialog();

            if (result == true)
            {
                if (!File.Exists(ExcelConstants.DownloadDirectory + Path.GetFileName(fileDialog.FileName)))
                {
                    File.Copy(fileDialog.FileName,
                        ExcelConstants.DownloadDirectory + Path.GetFileName(fileDialog.FileName));
                }

                var files = Directory
                    .GetFiles(ExcelConstants.DownloadDirectory)
                    .ToList();
                var fileNames = new StringBuilder();

                foreach (var file in files)
                {
                    fileNames.AppendLine(Path.GetFileName(file));
                }

                DownloadedFiles.Text = fileNames.ToString();
            }
        }
    }
}
