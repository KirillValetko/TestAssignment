using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using TestAssignment.DAL.Infrastructure.Settings;

namespace TestAssignment.DAL.Infrastructure
{
    public class BalanceDbContext
    {
        private readonly BalanceDbSettings _settings;

        public BalanceDbContext(IOptions<BalanceDbSettings> settings)
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
