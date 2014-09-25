using System.Text.RegularExpressions;

namespace MSG.DomainLogic
{
    public static class CommandLineParser
    {
        public static void Parse(string[] args, out bool showHelp, out string outputFile)
        {
            string parsedFileName = string.Empty;
            showHelp = false;

            foreach (string s in args)
            {
                if (s.StartsWith("/f:"))
                {
                    parsedFileName = ParseSwitch(s);
                }

                if (s.Equals("/?"))
                {
                    showHelp = true;
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
