using Dapper;
using TestAssignment.Common.Constants;
using TestAssignment.DAL.Infrastructure;
using TestAssignment.DAL.Repositories.Interfaces;

namespace TestAssignment.DAL.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly FileDbContext _context;

        public FileRepository(FileDbContext context)
        {
            _context = context;
        }

        public async Task FileBulkInsertAsync(string filepath)
        {
            var rowNumber = File.ReadLines(filepath).Count();
            using var connection = _context.CreateConnection();

            for (var i = 1; i <= rowNumber; i += 10000)
            {
                var sqlCommand = "BULK INSERT FileRow " +
                                 $"FROM '{filepath}' " +
                                 "WITH " +
                                 "(" +
                                 $"FIRSTROW = {i}, " +
                                 $"LASTROW = {i + 9999}, " +
                                 $"FIELDTERMINATOR = '{FileRowConstants.Delimiter}', " +
                                 "ROWTERMINATOR = '\\n'" +
                                 ");";

                await connection.ExecuteAsync(sqlCommand);
            }
        }

        public async Task<(long, double)> GetSumAndMedianAsync()
        {
            using var connection = _context.CreateConnection();
            var sqlCommand = "EXECUTE sp_GetSumAndMedian";
            var result = await connection.QueryFirstAsync<(long, double)>(sqlCommand);

            return result;
        }
    }
}
