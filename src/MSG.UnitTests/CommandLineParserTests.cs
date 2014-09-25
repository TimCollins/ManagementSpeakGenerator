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
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void QuestionMarkOnlyForValidHelpSwitch()
        {
            string outputFile;
            bool showHelp;
            string[] args = { "/?Fred" };

            CommandLineParser.Parse(args, out showHelp, out outputFile);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void NoSpaceBetweenQuestionMarkAndSlash()
        {
            string outputFile;
            bool showHelp;
            string[] args = { "/ ?" };

            CommandLineParser.Parse(args, out showHelp, out outputFile);
        }

        [Test]
        public void NoArgsSpecifiedThenHelpShouldBeShown()
        {
            string outputFile;
            bool showHelp;
            string[] args = new string[0];

            CommandLineParser.Parse(args, out showHelp, out outputFile);

            Assert.IsTrue(showHelp);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void UnsupportArgShouldGiveError()
        {
            string outputFile;
            bool showHelp;
            string[] args = { "/z" };

            CommandLineParser.Parse(args, out showHelp, out outputFile);
        }

        [Test]
        public void WhenOutputFileSpecifiedVarIsSet()
        {
            string outputFile;
            bool showHelp;
            string[] args = { @"/f:C:\home\somewhere\test.txt" };

            CommandLineParser.Parse(args, out showHelp, out outputFile);

            Assert.AreEqual(@"C:\home\somewhere\test.txt", outputFile);
        }

        [Test]
        public void WhenOutputFileNotSpecifiedDefaultIsUsed()
        {
            string outputFile;
            bool showHelp;
            string[] args = { @"/f:C:\Users\tcollins\Desktop\test.txt" };

            CommandLineParser.Parse(args, out showHelp, out outputFile);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\test.txt", outputFile);
        }
        
        // Invalid filename e.g. with spaces not surrounded by quotes.
        // Multiple args e.g. any 2 from 3 and all 3 together.
    }
}
