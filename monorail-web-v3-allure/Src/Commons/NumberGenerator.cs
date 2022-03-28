using System;

namespace monorail_web_v3.Commons
{
    public static class NumberGenerator
    {
        public static string GenerateRandomString()
        {
            return DateTime.Now.ToString("dd/MM/yyyy") + " " + new Random().Next(10, 99);
        }

        public static string GenerateRandomNumber()
        {
            return new Random().Next(100, 999).ToString();
        }

        public static string GenerateRandom4Digits()
        {
            return new Random().Next(1000, 9999).ToString();
        }

        public static string GenerateRandom7Digits()
        {
            return new Random().Next(1000000, 9999999).ToString();
        }

        public static string GetCurrentDate()
        {
            return DateTime.Now.ToString("ddMMyy");
        }
    }
}