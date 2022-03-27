using static monorail_web_v3.Commons.NumberGenerator;
using static monorail_web_v3.Database.PhoneNumber;

namespace monorail_web_v3.Commons
{
    public static class PhoneNumberGenerator
    {
        public static string GenerateNew202PhoneNumber()
        {
            string phoneNumber;
            bool phoneAlreadyExists;
            do
            {
                phoneNumber = "202" + GenerateRandom7Digits();
                phoneAlreadyExists = CheckIfPhoneNumberWasUsedOnUatAndDev(phoneNumber);
            } while (phoneAlreadyExists);

            return phoneNumber;
        }
    }
}