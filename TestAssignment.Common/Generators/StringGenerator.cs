using System.Security.Cryptography;
using System.Text;
using TestAssignment.Common.Constants;
using TestAssignment.Common.Generators.Interfaces;

namespace TestAssignment.Common.Generators
{
    public class StringGenerator : IStringGenerator
    {
        public string GenerateString(string characters)
        {
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < FileRowConstants.NumberOfCharacters; i++)
            {
                stringBuilder.Append(characters[RandomNumberGenerator.GetInt32(characters.Length)]);
            }

            return stringBuilder.ToString();
        }
    }
}
