using System.IO;
using MSG.DomainLogic;
using MSG.DomainLogic.Entities;
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
            string[] args = { "/?Fred" };

            CommandLineParser.Parse(args);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.UnsupportedSwitchException")]
        public void NoSpaceBetweenQuestionMarkAndSlash()
        {
            string[] args = { "/ ?" };

            CommandLineParser.Parse(args);
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
            string[] args = { "/z" };

            CommandLineParser.Parse(args);
        }

        [Test]
        public void WhenOutputFileSpecifiedVarIsSet()
        {
            string[] args = { @"/f:C:\home\somewhere\test.txt" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"C:\home\somewhere\test.txt", clArgs.OutputFile);
        }

        [Test]
        public void CapitalOutputFileSwitchIsSupported()
        {
            string[] args = { @"/F:C:\home\somewhere\test.txt" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"C:\home\somewhere\test.txt", clArgs.OutputFile);
        }

        [Test]
        public void WhenOutputFileNotSpecifiedDefaultIsUsed()
        {
            string[] args = { @"/f:C:\Users\tcollins\Desktop\test.txt" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\test.txt", clArgs.OutputFile);
        }

        [Test]
        public void HTMLOutputSwitchSupported()
        {
            string[] args = { @"/o:h" };
           
            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(OutputType.HTML, clArgs.OutputType);
        }

        [Test]
        public void JSONOutputSwitchSupported()
        {
            string[] args = { @"/o:j" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(OutputType.JSON, clArgs.OutputType);
        }

        [Test]
        public void TextOutputSwitchSupported()
        {
            string[] args = { @"/o:t" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(OutputType.Text, clArgs.OutputType);
        }

        [Test]
        public void XMLOutputSwitchSupported()
        {
            string[] args = { @"/o:x" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(OutputType.XML, clArgs.OutputType);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.InvalidSwitchException")]
        public void UnsupportedOutputSwitchThrowsException()
        {
            string[] args = { @"/o:b" };

            CommandLineParser.Parse(args);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.InvalidSwitchException")]
        public void CapitalHTMLOutputSwitchRejected()
        {
            string[] args = { @"/o:H" };

            CommandLineParser.Parse(args);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.InvalidSwitchException")]
        public void CapitalJSONOutputSwitchRejected()
        {
            string[] args = { @"/o:J" };

            CommandLineParser.Parse(args);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.InvalidSwitchException")]
        public void CapitalTextOutputSwitchRejected()
        {
            string[] args = { @"/o:T" };

            CommandLineParser.Parse(args);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.InvalidSwitchException")]
        public void CapitalXMLOutputSwitchRejected()
        {
            string[] args = { @"/o:X" };

            CommandLineParser.Parse(args);
        }

        [Test]
        public void CapitalOutputSwitchSupported()
        {
            string[] args = { @"/O:x" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(OutputType.XML, clArgs.OutputType);
        }

        [Test]
        public void WhenNoOutputFileSpecifiedDefaultIsUsed()
        {
            string[] args = { };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\msg_output.txt", clArgs.OutputFile);
        }

        [Test]
        public void WhenOutputTypeSpecifiedItIsUsed()
        {
            string[] args = {"/o:j"};

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\msg_output.json", clArgs.OutputFile);
        }

        [Test]
        public void WhenFolderSpecifiedItIsUsed()
        {
            string[] args = {"/o:j"};

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"C:\Users\tcollins\Desktop\msg_output.json", clArgs.OutputFile);
        }

        [Test]
        public void WhenFileNameSpecifiedItIsUsed()
        {
            string[] args = {@"/f:c:\temp\output"};

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"c:\temp\output.txt", clArgs.OutputFile);
        }

        [Test]
        public void WhenOutputTypeAndFileNameSpecifiedTheyAreUsed()
        {
            string[] args = {"/o:j", @"/f:c:\temp\output.json"};

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"c:\temp\output.json", clArgs.OutputFile);
        }

        [Test]
        public void FileNameWithNoExtensionSpecifiedUsesOutputType()
        {
            string[] args = { "/o:j", @"/f:c:\temp\output" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"c:\temp\output.json", clArgs.OutputFile);
        }

        [Test]
        public void WhenXMLSpecifiedItIsUsed()
        {
            string[] args = { "/o:x", @"/f:c:\temp\output.xml" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"c:\temp\output.xml", clArgs.OutputFile);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.InvalidSwitchException")]
        public void VerifyFileNameWithSpacesWithoutQuotesFails()
        {
            string[] args = { "/o:x", @"/f:c:\temp\output file.xml" };

            CommandLineParser.Parse(args);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.InvalidSwitchException")]
        public void VerifyFileNameWithSpacesWithSingleQuoteFails()
        {
            string[] args = { "/o:x", @"/f:""c:\temp\output file.xml" };

            CommandLineParser.Parse(args);
        }

        [Test]
        public void VerifyFileNameWithSpacesAndQuotesIsHandled()
        {
            string[] args = { "/o:x", @"/f:""c:\temp\output file.xml""" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"""c:\temp\output file.xml""", clArgs.OutputFile);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.InvalidSwitchException")]
        public void VerifyThatDisallowedFileCharsAreHandled()
        {
            string borkedFileName = @"/f:c:\temp\test" + string.Join("", Path.GetInvalidFileNameChars());
            string[] args = { "/o:x", borkedFileName };

            CommandLineParser.Parse(args);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.InvalidSwitchException")]
        public void VerifyThatDisallowedPathCharsAreHandled()
        {
            string borkedPathName = @"/f:c:\temp" + string.Join("", Path.GetInvalidPathChars());
            string[] args = { "/o:x", borkedPathName + @"\\test.xml" };

            CommandLineParser.Parse(args);
        }

        [Test]
        public void VerifyThatOrderDoesNotMatter()
        {
            string[] args = { @"/f:""c:\temp\output file.xml""", "/o:x" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(@"""c:\temp\output file.xml""", clArgs.OutputFile);
        }

        [Test]
        public void VerifyThatShowHelpTakesPrecedence()
        {
            // This doesn't really test that ShowHelp takes precedence. It shows that 3
            // switches can be specified.
            string[] args = { @"/f:""c:\temp\output file.xml""", "/o:x", "/?"};

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.IsTrue(clArgs.ShowHelp);
        }

        [Test]
        public void VerifyThatNumberParamIsSupported()
        {
            string[] args = { "/n:25" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(25, clArgs.SentenceCount);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.InvalidSwitchException")]
        public void VerifyNumberMustBeGreaterThanZero()
        {
            string[] args = { "/n:0" };

            CommandLineParser.Parse(args);
        }

        [Test]
        [ExpectedException("MSG.DomainLogic.InvalidSwitchException")]
        public void VerifyNumberCannotBeNegative()
        {
            string[] args = { "/n:-17" };

            CommandLineParser.Parse(args);
        }

        [Test]
        public void IfNoCountSpecifiedDefaultIsUsed()
        {
            string[] args = { @"/f:C:\home\somewhere\test.txt" };

            CommandLineArgs clArgs = CommandLineParser.Parse(args);

            Assert.AreEqual(50, clArgs.SentenceCount);
        }
    }
}
