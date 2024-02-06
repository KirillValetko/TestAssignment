using System.Text;
using TestAssignment.Common.Constants;
using TestAssignment.Common.Generators.Interfaces;

namespace TestAssignment.Common.Generators
{
    public class FileGenerator : IFileGenerator
    {
        private readonly IRowGenerator _rowGenerator;

        public FileGenerator(IRowGenerator rowGenerator)
        {
            _rowGenerator = rowGenerator;
        }

        public async Task GenerateFileAsync(string filename)
        {
            try
            {
                await using var streamWriter = new StreamWriter(FileConstants.Filepath + filename, 
                    false, Encoding.UTF8, FileConstants.BufferSize);
                var row = _rowGenerator.GenerateRow();

                for (var i = 1; i < FileConstants.RowNumber; i++)
                {
                    await streamWriter.WriteLineAsync(row);
                    row = _rowGenerator.GenerateRow();
                }
                
                await streamWriter.WriteAsync(row);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
