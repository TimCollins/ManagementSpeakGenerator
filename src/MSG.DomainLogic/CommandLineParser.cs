using System.Text.RegularExpressions;

namespace MSG.DomainLogic
{
    public static class CommandLineParser
    {
        public static void Parse(string[] args, out string outputFile)
        {
            string parsedFileName = string.Empty;

            foreach (string s in args)
            {
                if (s.StartsWith("/f:"))
                {
                    parsedFileName = ParseSwitch(s);
                }
            }

            outputFile = parsedFileName;
        }

        private static string ParseSwitch(string s)
        {
            string[] output = Regex.Split(s, @"/\w{1}:");

            return output[1];
        }
    }
}
