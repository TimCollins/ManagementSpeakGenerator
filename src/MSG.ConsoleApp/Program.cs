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

            Console.WriteLine("Writing test data to file...");
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\msg_output.txt";
            const int max = 50;
            StringBuilder output = new StringBuilder();

            List<Sentence> sentences = DomainFactory.Generator.GetSentences(max);
            for (int i = 0; i < max; i++)
            {
                output.Append(string.Format("{0}. {1}{2}", i + 1, sentences[i], Environment.NewLine));
            }

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.Write(output.ToString());
            }

            Console.WriteLine("Data written to {0}", fileName);

            string jsonData = new JavaScriptSerializer().Serialize(sentences);

            Util.WaitForEscape();
        }
    }
}
