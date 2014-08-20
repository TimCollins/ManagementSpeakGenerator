using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class FaukonTests
    {
        [Test]
        public void VerifyFaukonNeedTo()
        {
            MoqUtil.SetupRandMock(17, 5, 1, 2, 1, 1, 1, 1);
            List<string> output = DomainFactory.Generator.GetSentences(1);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual(1, output.Count);
            Assert.IsTrue(output[0].StartsWith("we need to "));
        }

        [Test]
        public void VerifyFaukonGotTo()
        {
            MoqUtil.SetupRandMock(17, 5, 2, 1, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("we've got to "));
        }

        [Test]
        public void VerifyFaukonUnitShould()
        {
            MoqUtil.SetupRandMock(17, 5, 3, 1, 1, 1, 1, 1);
            List<string> output = DomainFactory.Generator.GetSentences(1);

            MoqUtil.UndoMockRandomNumber();

            Assert.AreEqual(1, output.Count);
            Assert.IsTrue(output[0].StartsWith("the reporting unit should "));
        }

        [Test]
        public void VerifyFaukonControllingShould()
        {
            MoqUtil.SetupRandMock(17, 5, 4, 1, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("controlling should "));
        }

        [Test]
        public void VerifyFaukonActivate()
        {
            MoqUtil.SetupRandMock(17, 5, 5, 1, 1, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("we must activate "));
        }

        [Test]
        public void VerifyFaukonPursuing()
        {
            MoqUtil.SetupRandMock(17, 5, 6, 1, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("pursuing this route will enable us to "));
        }

        [Test]
        public void VerifyFaukonExtraMile()
        {
            MoqUtil.SetupRandMock(17, 5, 7, 1, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("we will go the extra mile to "));
        }

        [Test]
        public void VerifyFaukonWorkingHard()
        {
            MoqUtil.SetupRandMock(17, 5, 8, 1, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("we are working hard to "));
        }

        [Test]
        public void VerifyFaukonTirelessly()
        {
            MoqUtil.SetupRandMock(17, 5, 9, 1, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.StartsWith("we continue to work tirelessly and diligently to "));
        }

    }
}
