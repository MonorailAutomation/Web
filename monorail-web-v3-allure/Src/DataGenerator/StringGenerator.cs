using static monorail_web_v3.DataGenerator.DateGenerator;
using static monorail_web_v3.DataGenerator.NumberGenerator;

namespace monorail_web_v3.DataGenerator
{
    public static class StringGenerator
    {
        public static string GenerateStringWithNumber()
        {
            return GetCurrentDateFormatted() + " " + GenerateRandomDigits(2);
        }
    }
}