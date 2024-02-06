using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestAssignment.BLL.Services.Interfaces;
using TestAssignment.Common.Constants;

namespace TestAssignment.WPF.ViewModels
{
    public partial class FirstTaskViewModel : BaseViewModel
    {
        private readonly IFileService _fileService;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(MergeFilesCommand))]
        private string _filesGenerationStatus;

        [ObservableProperty]
        private string _filesMergeStatus;

        [ObservableProperty]
        private string _sequence;

        public FirstTaskViewModel(IFileService fileService)
        {
            _fileService = fileService;
        }

        private bool CanGenerateFiles()
        {
            var files = Directory.GetFiles(FileConstants.Filepath, FileConstants.FileSearchPattern);

            return files.Length == 0;
        }
        
        [RelayCommand(CanExecute = nameof(CanGenerateFiles))]
        private async Task GenerateFiles()
        {
            FilesGenerationStatus = "Files Generation Started";

            await Task.Run(_fileService.GenerateFilesAsync);
            
            FilesGenerationStatus = "Files Generation Ended";
            await Task.Delay(1000);
            
            FilesGenerationStatus = string.Empty;
        }

        private bool CanMergeFiles()
        {
            var files = Directory.GetFiles(FileConstants.Filepath, FileConstants.FileSearchPattern);

            return files.Length != 0;
        }

        [RelayCommand(CanExecute = nameof(CanMergeFiles))]
        private async Task MergeFiles()
        {
            FilesMergeStatus = "Files Merge Started";

            var linesDeleted = await Task.Run(async () => 
                await _fileService.MergeFilesAsync(Sequence));

            FilesMergeStatus = "Files Merge Ended";
            await Task.Delay(1000);

            FilesMergeStatus = $"Lines deleted: {linesDeleted}";
            await Task.Delay(2000);

            FilesMergeStatus = string.Empty;
            Sequence = string.Empty;
        }
    }
}
