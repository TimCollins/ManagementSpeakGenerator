using System.IO;
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
            string[] args = { "/?" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.IsTrue(clArgs.ShowHelp);
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
            string[] args = new string[0];

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.IsTrue(clArgs.ShowHelp);
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
        public void WhenOutputTypeSpecifiedItIsUsed()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = {"/o:j"};

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\msg_output.json", outputFile);
        }

        [Test]
        public void WhenFolderSpecifiedItIsUsed()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = {"/o:j"};

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\msg_output.json", outputFile);
        }

        [Test]
        public void WhenFileNameSpecifiedItIsUsed()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = {@"/f:c:\temp\output"};

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"c:\temp\output.txt", outputFile);
        }

        [Test]
        public void WhenOutputTypeAndFileNameSpecifiedTheyAreUsed()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = {"/o:j", @"/f:c:\temp\output.json"};

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"c:\temp\output.json", outputFile);
        }

        [Test]
        public void FileNameWithNoExtensionSpecifiedUsesOutputType()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { "/o:j", @"/f:c:\temp\output" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"c:\temp\output.json", outputFile);
        }

        [Test]
        public void WhenXMLSpecifiedItIsUsed()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { "/o:x", @"/f:c:\temp\output.xml" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"c:\temp\output.xml", outputFile);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void VerifyFileNameWithSpacesWithoutQuotesFails()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { "/o:x", @"/f:c:\temp\output file.xml" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void VerifyFileNameWithSpacesWithSingleQuoteFails()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { "/o:x", @"/f:""c:\temp\output file.xml" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        public void VerifyFileNameWithSpacesAndQuotesIsHandled()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { "/o:x", @"/f:""c:\temp\output file.xml""" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"""c:\temp\output file.xml""", outputFile);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void VerifyThatDisallowedFileCharsAreHandled()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;

            string borkedFileName = @"/f:c:\temp\test" + string.Join("", Path.GetInvalidFileNameChars());
            string[] args = { "/o:x", borkedFileName };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void VerifyThatDisallowedPathCharsAreHandled()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;

            string borkedPathName = @"/f:c:\temp" + string.Join("", Path.GetInvalidPathChars());
            string[] args = { "/o:x", borkedPathName + @"\\test.xml" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);
        }

        [Test]
        public void VerifyThatOrderDoesNotMatter()
        {
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { @"/f:""c:\temp\output file.xml""", "/o:x" };

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.AreEqual(@"""c:\temp\output file.xml""", outputFile);
        }

        [Test]
        public void VerifyThatShowHelpTakesPrecedence()
        {
            // This doesn't really test that ShowHelp takes precedence. It shows that 3
            // switches can be specified.
            string outputFile;
            bool showHelp;
            OutputType outputType;
            string[] args = { @"/f:""c:\temp\output file.xml""", "/o:x", "/?"};

            CommandLineParser.Parse(args, out showHelp, out outputFile, out outputType);

            Assert.IsTrue(showHelp);
        }

        [Test]
        public void VerifyThatNumberParamIsSupported()
        {
            
        }
    }
}
