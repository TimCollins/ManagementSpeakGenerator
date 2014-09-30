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

            try
            {
                OutputType outputType;
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
            
            const int max = 50;

            StringBuilder output = new StringBuilder();

            List<Sentence> sentences = DomainFactory.Generator.GetSentences(max);
            for (int i = 0; i < max; i++)
            {
                output.Append(string.Format("{0}. {1}{2}", sentences[i].ID, sentences[i].Text, Environment.NewLine));
            }

            string jsonData = new JavaScriptSerializer().Serialize(sentences);

            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                sw.Write(jsonData);
            }

            Console.WriteLine("Data written to {0}", outputFile);

            Util.WaitForEscape();
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
