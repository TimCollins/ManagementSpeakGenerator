using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class CommandLineParserTests
    {
        [Test]
        public void WhenOutputFileSpecifiedVarIsSet()
        {
            string outputFile;
            string[] args = { @"/f:C:\Users\tcollins\Desktop\" };

            CommandLineParser.Parse(args, out outputFile);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\", outputFile);
        }

        [Test]
        public void WhenOutputFileNotSpecifiedDefaultIsUsed()
        {

        }

        // No args specified

        // Unsupported arg e.g. /z
        // Invalid filename e.g. with spaces not surrounded by quotes.

    }
}
