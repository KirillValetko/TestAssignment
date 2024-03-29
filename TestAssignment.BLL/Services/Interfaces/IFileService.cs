﻿namespace TestAssignment.BLL.Services.Interfaces
{
    public interface IFileService
    {
        Task GenerateFilesAsync();
        Task<int> MergeFilesAsync(string sequence);
        Task ExportFileAsync();
        Task<(long, double)> GetSumAndMedianAsync();
    }
}
