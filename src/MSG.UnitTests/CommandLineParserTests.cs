using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class CommandLineParserTests
    {
        [Test]
        public void WhenQuestionMarkSpecifiedHelpWillBeShown()
        {
            string outputFile;
            bool showHelp;
            string[] args = { "/?" };

            CommandLineParser.Parse(args, out showHelp, out outputFile);

            Assert.IsEmpty(outputFile);
            Assert.IsTrue(showHelp);
        }

        [Test]
        public void WhenOutputFileSpecifiedVarIsSet()
        {
            string outputFile;
            bool showHelp;
            string[] args = { @"/f:C:\Users\tcollins\Desktop\" };

            CommandLineParser.Parse(args, out showHelp, out outputFile);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\", outputFile);
        }

        [Test]
        public void WhenOutputFileNotSpecifiedDefaultIsUsed()
        {

        }

        // No args specified

        // Unsupported arg e.g. /z
        // Invalid filename e.g. with spaces not surrounded by quotes.
        // Unsupported arg like /?fred should produce an error.

    }
}
