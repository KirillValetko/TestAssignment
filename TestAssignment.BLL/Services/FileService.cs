﻿using System.Text;
using TestAssignment.BLL.Services.Interfaces;
using TestAssignment.Common.Constants;
using TestAssignment.Common.Generators.Interfaces;
using TestAssignment.DAL.Repositories.Interfaces;

namespace TestAssignment.BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IFileGenerator _fileGenerator;
        private readonly IFileRepository _fileRepository;

        public FileService(IFileGenerator fileGenerator,
            IFileRepository fileRepository)
        {
            _fileGenerator = fileGenerator;
            _fileRepository = fileRepository;
        }

        public async Task GenerateFilesAsync()
        {
            var generateFileTasks = new List<Task>();

            for (var i = 1; i <= FileConstants.FileNumber; i++)
            {
                var generateFileTask = _fileGenerator.GenerateFileAsync($"{i}" + FileConstants.FileType);
                generateFileTasks.Add(generateFileTask);
            }

            await Task.WhenAll(generateFileTasks);
        }

        public async Task<int> MergeFilesAsync(string sequence)
        {
            try
            {
                var totalLinesDeleted = 0;

                var files = Directory
                    .GetFiles(FileConstants.Filepath, FileConstants.FileSearchPattern)
                    .Where(f => !f.Contains(FileConstants.UnitedFile))
                    .ToList();

                if (sequence != null)
                {
                    foreach (var file in files)
                    {
                        var linesDeleted = await RewriteFileAsync(file, sequence);
                        totalLinesDeleted += linesDeleted;
                    }
                }

                await using var streamWriter = new StreamWriter(FileConstants.Filepath + FileConstants.UnitedFile,
                    false, Encoding.UTF8, FileConstants.BufferSize);

                for (var i = 0; i < files.Count; i++)
                {
                    using var streamReader = new StreamReader(files[i], Encoding.UTF8);
                    var fileText = await streamReader.ReadToEndAsync();

                    if (i != files.Count - 1)
                    {
                        await streamWriter.WriteLineAsync(fileText);
                    }
                    else
                    {
                        await streamWriter.WriteAsync(fileText);
                    }
                }

                return totalLinesDeleted;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task ExportFileAsync()
        {
            var file = Directory
                .GetFiles(FileConstants.Filepath, FileConstants.FileSearchPattern)
                .FirstOrDefault(f => f.Contains(FileConstants.UnitedFile));

            await _fileRepository.FileBulkInsertAsync(file);
        }

        public async Task<(long, double)> GetSumAndMedianAsync()
        {
            var result = await _fileRepository.GetSumAndMedianAsync();

            return result;
        }

        private async Task<int> RewriteFileAsync(string filepath, string sequence)
        {
            var tempFile = Path.GetTempFileName();

            await using var streamWriter = new StreamWriter(tempFile, false, Encoding.UTF8, FileConstants.BufferSize);
            var linesToKeep = File.ReadLines(filepath, Encoding.UTF8).Where(l => !l.Contains(sequence)).ToList();

            for (var i = 0; i < linesToKeep.Count - 1; i++)
            {
                await streamWriter.WriteLineAsync(linesToKeep[i]);
            }

            await streamWriter.WriteAsync(linesToKeep.Last());
            streamWriter.Close();

            File.Delete(filepath);
            File.Move(tempFile, filepath);

            return FileConstants.RowNumber - linesToKeep.Count;
        }
    }
}
