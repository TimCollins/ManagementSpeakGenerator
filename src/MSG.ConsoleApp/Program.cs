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

            string outputFile;
            string outputFormat;
            CommandLineParser.Parse(args, out outputFile);

            Console.WriteLine("Writing test data to file...");
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            string baseFile = "msg_output";
            string fileName = basePath + baseFile + ".txt";
            const int max = 50;
            StringBuilder output = new StringBuilder();

            List<Sentence> sentences = DomainFactory.Generator.GetSentences(max);
            for (int i = 0; i < max; i++)
            {
                output.Append(string.Format("{0}. {1}{2}", sentences[i].ID, sentences[i].Text, Environment.NewLine));
            }

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(output.ToString());
            }

            Console.WriteLine("Data written to {0}", fileName);

            string jsonData = new JavaScriptSerializer().Serialize(sentences);
            fileName = basePath + baseFile + ".json";

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(jsonData);
            }

            Util.WaitForEscape();
        }
    }
}
