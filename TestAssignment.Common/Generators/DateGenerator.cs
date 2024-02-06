using System.Security.Cryptography;
using TestAssignment.Common.Constants;
using TestAssignment.Common.Generators.Interfaces;

namespace TestAssignment.Common.Generators
{
    public class DateGenerator : IDateGenerator
    {
        public string GenerateDate()
        {
            var currentDate = DateTime.Today;
            var numberOfDays = (currentDate - currentDate.AddYears(FileRowConstants.SpanOfYears)).Days;
            var randomDate = currentDate.AddDays(-RandomNumberGenerator.GetInt32(numberOfDays));

            return randomDate.ToString(FileRowConstants.DateFormat);
        }
    }
}
