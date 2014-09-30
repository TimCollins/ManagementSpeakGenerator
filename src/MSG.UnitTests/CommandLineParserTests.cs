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
        public void CapitalOutputFileSwitchIsSupported()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { @"/F:C:\home\somewhere\test.txt" };

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

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void UnsupportedOutputSwitchThrowsException()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;

            string[] args = { @"/o:b" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void CapitalHTMLOutputSwitchRejected()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;

            string[] args = { @"/o:H" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void CapitalJSONOutputSwitchRejected()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;

            string[] args = { @"/o:J" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void CapitalTextOutputSwitchRejected()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;

            string[] args = { @"/o:T" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void CapitalXMLOutputSwitchRejected()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;

            string[] args = { @"/o:X" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        public void CapitalOutputSwitchSupported()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;

            string[] args = { @"/O:x" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
            Assert.AreEqual(OutputType.XML, outputType);
        }

        [Test]
        public void WhenNoOutputFileSpecifiedDefaultIsUsed()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\msg_output.txt", outputFile);
        }

        [Test]
        public void WhenExtensionSpecifiedItIsUsed()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { @"/o:j" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\msg_output.json", outputFile);
        }

        // Test the output formats
        // When nothing specified, a default of ".txt" should be used.
        

        // Invalid filename e.g. with spaces not surrounded by quotes.
        // Multiple args e.g. any 2 from 3 and all 3 together.
    }
}
