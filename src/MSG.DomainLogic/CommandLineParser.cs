using System.Text.RegularExpressions;

namespace MSG.DomainLogic
{
    public static class CommandLineParser
    {
        public static void Parse(string[] args, out bool showHelp, out string outputFile, out OutputType outputType)
        {
            string parsedFileName = string.Empty;
            showHelp = false;
            outputType = OutputType.Text;

            if (args.Length == 0)
            {
                showHelp = true;
            }

            foreach (string s in args)
            {
                if (s.ToLower().StartsWith("/f:"))
                {
                    parsedFileName = ParseSwitch(s);
                }
                else if (s.Equals("/?"))
                {
                    showHelp = true;
                }
                else if (s.ToLower().StartsWith("/o:"))
                {
                    outputType = ParseOutputType(s);
                }
                else
                {
                    throw new UnsupportedSwitchException(s);
                }
            }

            outputFile = parsedFileName;
        }

        private static OutputType ParseOutputType(string s)
        {
            string outputType = ParseSwitch(s);

            switch (outputType)
            {
                case "h":
                    return OutputType.HTML;
                case "j":
                    return OutputType.JSON;
                case "t":
                    return OutputType.Text;
                case "x":
                    return OutputType.XML;
            }

            throw new UnsupportedSwitchException(s);
        }

        private static string ParseSwitch(string s)
        {
            string[] output = Regex.Split(s, @"/\w{1}:");

            return output[1];
        }
    }
}
