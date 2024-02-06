using System.Text;
using TestAssignment.Common.Constants;
using TestAssignment.Common.Generators.Interfaces;

namespace TestAssignment.Common.Generators
{
    public class RowGenerator : IRowGenerator
    {
        private readonly IDateGenerator _dateGenerator;
        private readonly IStringGenerator _stringGenerator;

        public RowGenerator(IDateGenerator dateGenerator,
            IStringGenerator stringGenerator)
        {
            _dateGenerator = dateGenerator;
            _stringGenerator = stringGenerator;
        }

        public StringBuilder GenerateRow()
        {
            var row = new StringBuilder();

            var date = _dateGenerator.GenerateDate();
            row.Append(date);
            row.Append(FileRowConstants.Delimiter);

            var englishLetters = _stringGenerator.GenerateString(FileRowConstants.EnglishLetters);
            row.Append(englishLetters);
            row.Append(FileRowConstants.Delimiter);

            var russianLetters = _stringGenerator.GenerateString(FileRowConstants.RussianLetters);
            row.Append(russianLetters);
            row.Append(FileRowConstants.Delimiter);

            var random = new Random();
            row.Append(
                (random
                    .Next(FileRowConstants.IntUpperBound) * FileRowConstants.ObligatoryDivider + FileRowConstants.IntLowerBound)
                .ToString());
            row.Append(FileRowConstants.Delimiter);

            row.Append(
                (random.NextDouble() * FileRowConstants.DoubleUpperBound + FileRowConstants.DoubleLowerBound)
                .ToString(FileRowConstants.DoubleFormat));

            return row;
        }
    }
}
