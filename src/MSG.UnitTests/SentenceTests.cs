using System;
using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class SentenceTests
    {
        [Test]
        public void ExceptionThrownForNegativeCount()
        {
            Assert.Throws<ArgumentException>(() => DomainFactory.Generator.GetSentences(-2));
        }

        [Test]
        public void ExceptionThrownForZeroCount()
        {
            Assert.Throws<ArgumentException>(() => DomainFactory.Generator.GetSentences(0));
        }

        [Test]
        public void VerifyGetSentences()
        {
            // If GetSentences is called twice then there should be 2 sentences in the output.
            // Specify some numbers to get specific output and verify spacing.

            MoqUtil.SetupRandMock(  17, 5, 1, 1, 1, 1, 1, 
                                    18, 5, 1, 1, 1, 1, 3, 4, 6, 2, 5, 1, 2, 1);
            List<string> output = DomainFactory.Generator.GetSentences(2);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual(2, output.Count);
            Assert.AreEqual("We need to interactively streamline the process going forward.", output[0]);
            Assert.AreEqual("We need to interactively streamline the process across the board; this is why pursuing this route will enable us to credibly streamline the process within the industry.", output[1]);
        }

        [Test]
        public void FullStopErrorProjections()
        {
            MoqUtil.SetupRandMock(new[]{19, 24, 2, 5, 49, 17, 36, 8, 25, 161, 80, 122, 1, 134, 5, 5, 5, 20, 26, 1, 88, 182, 72, 5, 146});
            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The resources maximise the cultural, fast-growth, business philosophies; nevertheless we must activate the silo to efficiently manage our projections.", output);
        }

        [Test]
        public void VerifyReachOutTo()
        {
            MoqUtil.SetupRandMock(new[] {8, 46, 2, 9, 66, 66, 62, 17, 143, 189, 65, 6, 26});
            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("The standard-setters reach out to our value-driven initiatives up-front.", output);
        }

        [Test]
        public void FixExtraSpaceBeforeComma()
        {
            MoqUtil.SetupRandMock(new[] {18, 100, 45, 71, 268, 123, 88, 1, 94, 4, 17, 1, 1, 3, 6, 3, 1, 7, 128, 56, 1, 19, 109, 304, 153, 4, 72, 2, 98, 11, 2, 21});
            string output = DomainFactory.Generator.GetSentences(1)[0];
            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual("Cross fertilization, investor confidence and branding drive the Managing Co-Head of Customer Relations; this is why our long-term change promotes the human resources relative to our peers.", output);
        }
    }
}
