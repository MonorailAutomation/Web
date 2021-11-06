using System;

namespace monorail_web_v3.Commons
{
    public static class RandomGenerator
    {
        public static string GenerateRandomString()
        {
            return DateTime.Now.ToString("dd/MM/yyyy") + " " + new Random().Next(10, 99);
        }
        
        public static string GenerateRandomNumber()
        {
            return new Random().Next(100, 999).ToString();
        }
    }
}