using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using MSG.DomainLogic;

namespace MSG.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Management-Speak Generator.");

            CommandLineArgs cmdArgs;
            try
            {
                cmdArgs = CommandLineParser.Parse(args);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return;
            }

            if (cmdArgs.ShowHelp)
            {
                ShowHelp();
                Util.WaitForEscape();
                return;
            }

            Console.WriteLine("Writing test data to to {0}...", cmdArgs.OutputFile);
            const int max = 50;
            List<Sentence> sentences = DomainFactory.Generator.GetSentences(max);
            string serialisedData = GetSerialisedData(cmdArgs.OutputType, sentences, max);

            using (StreamWriter sw = new StreamWriter(cmdArgs.OutputFile))
            {
                sw.Write(serialisedData);
            }

            Console.WriteLine("Data written to {0}", cmdArgs.OutputFile);

            Util.WaitForEscape();
        }

        private static string GetSerialisedData(OutputType outputType, List<Sentence> sentences, int max)
        {
            switch (outputType)
            {
                case OutputType.HTML:
                    return SerialiseAsHTML(sentences, max);
                case OutputType.JSON:
                    return new JavaScriptSerializer().Serialize(sentences);
                case OutputType.Text:
                    return SerialiseAsText(sentences, max);
                default:
                    return SerialiseAsXML(sentences);
            }
        }

        private static string SerialiseAsHTML(List<Sentence> sentences, int count)
        {
            StringBuilder htmlOutput = new StringBuilder();

            htmlOutput.Append("<ol>" + Environment.NewLine);

            for (int i = 0; i < count; i++)
            {
                htmlOutput.Append(string.Format("\t<li>{0}</li>{1}", sentences[i].Text, Environment.NewLine));
            }

            htmlOutput.Append("</ol>");

            return htmlOutput.ToString();
        }

        private static string SerialiseAsText(List<Sentence> sentences, int count)
        {
            StringBuilder textOutput = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                textOutput.Append(string.Format("{0}. {1}{2}", sentences[i].ID, sentences[i].Text,
                    Environment.NewLine));
            }
            return textOutput.ToString();
        }

        private static string SerialiseAsXML(List<Sentence> sentences)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            XmlSerializer xs = new XmlSerializer(sentences.GetType());
            StringWriter sw = new StringWriter();

            xs.Serialize(sw, sentences, ns);

            return sw.GetStringBuilder().ToString();
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
            Console.WriteLine("\t\t\tfrom the /o parameter so if no extension is specified by the user then a default of \".txt\" will be used.");
        }
    }
}
