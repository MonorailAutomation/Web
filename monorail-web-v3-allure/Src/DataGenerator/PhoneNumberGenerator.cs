using static monorail_web_v3.DataGenerator.NumberGenerator;
using static monorail_web_v3.Database.PhoneNumber;

namespace monorail_web_v3.DataGenerator
{
    public static class PhoneNumberGenerator
    {
        public static string GenerateNew202PhoneNumber()
        {
            string phoneNumber;
            bool phoneAlreadyExists;
            do
            {
                phoneNumber = "202" + GenerateRandomDigits(7);
                phoneAlreadyExists = CheckIfPhoneNumberWasUsedOnUatAndDev(phoneNumber);
            } while (phoneAlreadyExists);

            return phoneNumber;
        }
    }
}