using System;

namespace monorail_web_v3.DataGenerator
{
    public static class NumberGenerator
    {
        public static string GenerateRandomDigits(int numberOfDigits)
        {
            var firstNumber = "1";
            var secondNumber = "9";

            for (var i = 1; i < numberOfDigits; i++)
            {
                firstNumber += '0';
                secondNumber += '9';
            }

            return new Random().Next(int.Parse(firstNumber), int.Parse(secondNumber)).ToString();
        }
    }
}