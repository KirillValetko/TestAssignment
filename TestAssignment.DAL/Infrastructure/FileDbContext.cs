using Microsoft.Extensions.Options;
using System.Data;
using Microsoft.Data.SqlClient;
using TestAssignment.DAL.Infrastructure.Settings;

namespace TestAssignment.DAL.Infrastructure
{
    public class FileDbContext
    {
        private readonly FileDbSettings _settings;

        public FileDbContext(IOptions<FileDbSettings> settings)
        {
            _settings = settings.Value;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = _settings.ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
