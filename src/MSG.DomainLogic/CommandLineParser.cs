using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MSG.DomainLogic
{
    public static class CommandLineParser
    {
        public static CommandLineArgs Parse(string[] args)
        {
            CommandLineArgs commandLineArgs = new CommandLineArgs();
            string parsedFileName = string.Empty;

            if (args.Length == 0)
            {
                commandLineArgs.ShowHelp = true;
            }

            foreach (string s in args)
            {
                if (s.ToLower().StartsWith("/f:"))
                {
                    parsedFileName = ParseSwitch(s);
                }
                else if (s.Equals("/?"))
                {
                    commandLineArgs.ShowHelp = true;
                }
                else if (s.ToLower().StartsWith("/o:"))
                {
                    commandLineArgs.OutputType = ParseOutputType(s);
                }
                else
                {
                    throw new UnsupportedSwitchException(s);
                }
            }

            commandLineArgs.OutputFile = string.IsNullOrEmpty(parsedFileName)
                ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\msg_output" + GetExtension(commandLineArgs.OutputType)
                : GetFileName(parsedFileName, commandLineArgs.OutputType);

            return commandLineArgs;
        }

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

            outputFile = string.IsNullOrEmpty(parsedFileName)
                ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\msg_output" + GetExtension(outputType)
                : GetFileName(parsedFileName, outputType);
        }

        private static string GetFileName(string parsedFileName, OutputType outputType)
        {
            // If there is no file extension provided then append ".txt"
            // Not 100% sure this is the best thing to do. It might be better to leave the
            // file as-is.

            if (parsedFileName.IndexOfAny(Path.GetInvalidPathChars()) > 0)
            {
                throw new UnsupportedSwitchException("Invalid path specified: " + parsedFileName);
            }

            string fileOnly = GetFileOnly(parsedFileName);

            if ((fileOnly.IndexOfAny(Path.GetInvalidFileNameChars()) > 0) || 
                (parsedFileName.Contains(" ") && !ContainsMatchedQuotes(parsedFileName)))
            {
                throw new UnsupportedSwitchException("Invalid filename specified: " + parsedFileName);
            }

            return parsedFileName.Contains(".")
                ? parsedFileName
                : parsedFileName + GetExtension(outputType);
        }

        private static string GetFileOnly(string parsedFileName)
        {
            string fileOnly = parsedFileName.Substring(parsedFileName.LastIndexOf('\\') + 1);

            return fileOnly.EndsWith("\"") 
                ? fileOnly.Remove(fileOnly.Length - 1) 
                : fileOnly;
        }

        private static bool ContainsMatchedQuotes(string s)
        {
            Match m = Regex.Match(s, "\".*\"");

            return m.Success;
        }

        private static string GetExtension(OutputType outputType)
        {
            switch (outputType)
            {
                case OutputType.HTML:
                    return ".html";
                case OutputType.JSON:
                    return ".json";
                case OutputType.Text:
                    return ".txt";
                default:
                    return ".xml";
            }
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
