using System.Text.RegularExpressions;

namespace MSG.DomainLogic
{
    public static class CommandLineParser
    {
        public static void Parse(string[] args, out bool showHelp, out string outputFile)
        {
            string parsedFileName = string.Empty;
            showHelp = false;

            if (args.Length == 0)
            {
                showHelp = true;
            }

            foreach (string s in args)
            {
                if (s.StartsWith("/f:"))
                {
                    parsedFileName = ParseSwitch(s);
                }
                else if (s.Equals("/?"))
                {
                    showHelp = true;
                }
                else
                {
                    throw new UnsupportedSwitchException(s);
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
