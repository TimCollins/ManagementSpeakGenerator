using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using MSG.DomainLogic;

namespace MSG.ConsoleApp
{
    class Program
    {
// If this is a debug build then define _testCounter
#if DEBUG
        private static int _testCounter;
#endif

        static void Main(string[] args)
        {
            // Call the method that should only exist in a debug build.
            // In release mode this line will generate an error because method arguments
            // must be well defined at the point of the method call. This holds true even
            // if the method itself is going to be removed. In this case the compiler knows
            // nothing about _testCounter because its declaration has been omitted so the 
            // initial lexical analysis of the file fails even though Test() itself is going
            // to be removed.
            // See http://blogs.msdn.com/b/ericlippert/archive/2009/09/10/what-s-the-difference-between-conditional-compilation-and-the-conditional-attribute.aspx
            // and http://stackoverflow.com/q/3788605/137001
            // also http://stackoverflow.com/q/2104099

            Test(_testCounter++);

            Console.WriteLine("Management-Speak Generator.");

            Console.WriteLine("Writing test data to file...");
            string fileName = Directory.GetCurrentDirectory() + "\\output.txt";

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                const int max = 1;

                List<string> sentences = DomainFactory.Generator.GetSentences(max);
                for (int i = 0; i < max; i++)
                {
                    sw.Write("{0}. {1}{2}", i + 1, sentences[i], Environment.NewLine);
                }
            }

            Console.WriteLine("Data written to {0}", fileName);
            Util.WaitForEscape();
        }

        // Define a method that should only exist in a debug build.
        [Conditional("DEBUG")]
        private static void Test(int i)
        {
            // Do stuff
        }
    }
}
