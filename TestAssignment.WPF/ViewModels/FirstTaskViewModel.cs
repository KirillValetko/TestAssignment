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
        [NotifyCanExecuteChangedFor(nameof(ExportFileCommand))]
        private string _filesMergeStatus;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ExecuteStoredProcedureCommand))]
        private string _fileExportStatus;

        [ObservableProperty]
        private string _storedProcedureExecutionStatus;

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

            return files.Length != 0 && !files.Any(f => f.Contains(FileConstants.UnitedFile));
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

        private bool CanExportFile()
        {
            var files = Directory.GetFiles(FileConstants.Filepath, FileConstants.FileSearchPattern)
                .FirstOrDefault(f => f.Contains(FileConstants.UnitedFile));

            return files != null;
        }

        [RelayCommand(CanExecute = nameof(CanExportFile))]
        private async Task ExportFile()
        {
            FileExportStatus = "Export Started";
            await Task.Run(_fileService.ExportFileAsync);
            FileExportStatus = "Export Ended";
            await Task.Delay(1000);
            FileExportStatus = string.Empty;
        }

        private bool CanExecuteStoredProcedure()
        {
            return CanExportFile();
        }

        [RelayCommand(CanExecute = nameof(CanExecuteStoredProcedure))]
        private async Task ExecuteStoredProcedure()
        {
            var result = await Task.Run(async () =>
                await _fileService.GetSumAndMedianAsync());
            StoredProcedureExecutionStatus = $"Sum of integers: {result.Item1}\nMedian of doubles: {result.Item2}";
            await Task.Delay(2000);
            StoredProcedureExecutionStatus = string.Empty;
        }
    }
}
