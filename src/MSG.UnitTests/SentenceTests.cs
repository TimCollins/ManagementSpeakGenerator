using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class SentenceTests
    {
        [Test]
        public void VerifyGetSentences()
        {
            // If GetSentences is called twice then there should be 2 sentences in the output.
            // Specify some numbers to get specific output and verify spacing.

            MoqUtil.SetupRandMock(  17, 5, 1, 1, 1, 1, 1, 
                                    18, 5, 1, 1, 1, 1, 3, 4, 6, 2, 5, 2, 1);
            List<string> output = DomainFactory.Generator.GetSentences(2);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual(2, output.Count);
            Assert.AreEqual("we need to interactively streamline the process going forward", output[0]);
            Assert.AreEqual("we need to interactively streamline the process across the board; this is why pursuing this route will enable us to credibly address the overarching issues going forward", output[1]);
        }

        [Test]
        public void VerifyFaukonNeedTo()
        {
            MoqUtil.SetupRandMock(17, 5, 1, 2, 1, 1, 1);
            List<string> output = DomainFactory.Generator.GetSentences(1);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual(1, output.Count);
            Assert.IsTrue(output[0].StartsWith("we need to "));
        }

        [Test]
        public void VerifyFaukonGotTo()
        {
            MoqUtil.SetupRandMock(17, 5, 2, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("we've got to "));
        }

        [Test]
        public void VerifyFaukonUnitShould()
        {
            MoqUtil.SetupRandMock(17, 5, 3, 1, 1, 1, 1);
            List<string> output = DomainFactory.Generator.GetSentences(1);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual(1, output.Count);
            Assert.IsTrue(output[0].StartsWith("the reporting unit should "));
        }

        [Test]
        public void VerifyFaukonControllingShould()
        {
            MoqUtil.SetupRandMock(17, 5, 4, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("controlling should "));
        }

        [Test]
        public void VerifyFaukonActivate()
        {
            MoqUtil.SetupRandMock(17, 5, 5, 1, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("we must activate "));
        }

        [Test]
        public void VerifyFaukonPursuing()
        {
            MoqUtil.SetupRandMock(17, 5, 6, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("pursuing this route will enable us to "));
        }

        [Test]
        public void VerifyFaukonExtraMile()
        {
            MoqUtil.SetupRandMock(17, 5, 7, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("we will go the extra mile to "));
        }

        [Test]
        public void VerifyFaukonWorkingHard()
        {
            MoqUtil.SetupRandMock(17, 5, 8, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("we are working hard to "));
        }

        [Test]
        public void VerifyFaukonTirelessly()
        {
            MoqUtil.SetupRandMock(17, 5, 9, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("we continue to work tirelessly and diligently to "));
        }

        [Test]
        public void VerifyEventualAdverbInteractively()
        {
            MoqUtil.SetupRandMock(21, 6, 1, 9, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(" interactively "));
        }

        [Test]
        public void VerifyEventualAdverbCredibly()
        {
            MoqUtil.SetupRandMock(17, 5, 9, 2, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(" credibly "));
        }

        [Test]
        public void VerifyEventualAdverbStrategically()
        {
            MoqUtil.SetupRandMock(17, 5, 9, 10, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(" strategically "));
        }

        [Test]
        public void VerifyEventualAdverbConservatively()
        {
            MoqUtil.SetupRandMock(17, 5, 9, 17, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(" conservatively "));
        }
    }
}
