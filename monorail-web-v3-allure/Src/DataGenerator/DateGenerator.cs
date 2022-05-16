using static System.DateTime;

namespace monorail_web_v3.DataGenerator
{
    public static class DateGenerator
    {
        public static string GetCurrentDatePlain()
        {
            return Now.ToString("ddMMyy");
        }

        public static string GetCurrentDateFormatted()
        {
            return Now.ToString("dd/MM/yyyy");
        }
    }
}