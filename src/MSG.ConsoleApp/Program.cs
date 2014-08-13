using System;
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
                for (int i = 0; i < 500; i++)
                {
                    sw.Write(DomainFactory.Generator.GetBoss() + Environment.NewLine);
                }
            }

            Console.WriteLine("Data written to {0}", fileName);
            Util.WaitForEscape();
        }
    }
}
