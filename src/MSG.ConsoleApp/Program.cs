using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using MSG.DomainLogic;

namespace MSG.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Management-Speak Generator.");

            bool showHelp;
            string outputFile;
            string outputFormat;
            OutputType outputType;
            try
            {
                CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return;
            }

            if (showHelp)
            {
                ShowHelp();
                Util.WaitForEscape();
                return;
            }

            Console.WriteLine("Writing test data to file...");
            // None of the logic here is unit tested.

            string basePath = GetBasePath(outputFile);
            string baseFile = string.IsNullOrEmpty(outputFile) 
                ? "msg_output" 
                : outputFile;
            string fileName = baseFile + GetExtension(outputType);
            const int max = 50;

            StringBuilder output = new StringBuilder();

            List<Sentence> sentences = DomainFactory.Generator.GetSentences(max);
            for (int i = 0; i < max; i++)
            {
                output.Append(string.Format("{0}. {1}{2}", sentences[i].ID, sentences[i].Text, Environment.NewLine));
            }

            string jsonData = new JavaScriptSerializer().Serialize(sentences);

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(jsonData);
            }

            Console.WriteLine("Data written to {0}", fileName);

            Util.WaitForEscape();
        }

        private static string GetBasePath(string outputFile)
        {
            if (string.IsNullOrEmpty(outputFile))
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // If a full path has been specified then use it otherwise use a path
            // relative to the current folder.
            string path = outputFile[1] == ':'
                ? outputFile
                : Environment.CurrentDirectory;

            return path;
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

        private static void HandleException(Exception ex)
        {
            Console.WriteLine("There was a problem parsing the command-line switches." + 
                " Please check the inputted data and try again.");
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Supported command-line arguments:");
            Console.WriteLine("/?\t\t\tShow help");
            Console.Write("/o:[x|j|h|t]\t\tSpecify output format of XML, JSON, HTML or Text. If not ");
            Console.WriteLine("\t\t\tsupplied then a default of text will be used.");
            Console.WriteLine("/f:[file]\t\tSpecify output filename. If not supplied then a file ");
            Console.WriteLine("\t\t\tcalled \"msg_output\" on the user's desktop will be ");
            Console.WriteLine("\t\t\tcreated. The output filename extension will be derived ");
            Console.WriteLine("\t\t\tfrom the /o parameter.");
        }
    }
}
