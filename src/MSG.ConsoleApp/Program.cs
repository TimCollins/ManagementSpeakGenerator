using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using MSG.DomainLogic;

namespace MSG.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Management-Speak Generator.");

            Console.WriteLine("Writing test data to file...");
            string fileName = Directory.GetCurrentDirectory() + "\\output.txt";

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                const int max = 500;

                List<string> sentences = DomainFactory.Generator.GetSentences(max);
                for (int i = 0; i < max; i++)
                {
                    sw.Write("{0}. {1}{2}", i + 1, sentences[i], Environment.NewLine);
                }
            }

            Console.WriteLine("Data written to {0}", fileName);
            Util.WaitForEscape();
        }
    }
}
