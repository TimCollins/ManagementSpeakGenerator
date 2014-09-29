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
            OutputType outputType;
            string[] args = { "/?" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.IsEmpty(outputFile);
            Assert.IsTrue(showHelp);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void QuestionMarkOnlyForValidHelpSwitch()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { "/?Fred" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void NoSpaceBetweenQuestionMarkAndSlash()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { "/ ?" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        public void NoArgsSpecifiedThenHelpShouldBeShown()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = new string[0];

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.IsTrue(showHelp);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void UnsupportedArgShouldGiveError()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { "/z" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        public void WhenOutputFileSpecifiedVarIsSet()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { @"/f:C:\home\somewhere\test.txt" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"C:\home\somewhere\test.txt", outputFile);
        }

        [Test]
        public void WhenOutputFileNotSpecifiedDefaultIsUsed()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { @"/f:C:\Users\tcollins\Desktop\test.txt" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\test.txt", outputFile);
        }

        [Test]
        public void HTMLOutputSwitchSupported()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;

            string[] args = { @"/o:h" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(OutputType.HTML, outputType);
        }

        [Test]
        public void JSONOutputSwitchSupported()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;

            string[] args = { @"/o:j" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(OutputType.JSON, outputType);
        }

        [Test]
        public void TextOutputSwitchSupported()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;

            string[] args = { @"/o:t" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(OutputType.Text, outputType);
        }

        [Test]
        public void XMLOutputSwitchSupported()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            
            string[] args = { @"/o:x" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(OutputType.XML, outputType);
        }

        // Test the output formats
        // When nothing specified, a default of ".txt" should be used.
        // When "/o:x" specified, XML should be used.
        // When "/o:j" specified, JSON should be used.
        // When "/o:h" specified, HTML should be used.
        // When "/o:t" specified, plain text should be used.

        // Test capitalisation on all options.


        // Invalid filename e.g. with spaces not surrounded by quotes.
        // Multiple args e.g. any 2 from 3 and all 3 together.
    }
}
