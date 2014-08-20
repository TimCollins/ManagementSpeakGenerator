using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class EventualAdverbTests
    {
        [Test]
        public void VerifyEventualAdverbInteractively()
        {
            MoqUtil.SetupRandMock(21, 6, 1, 9, 1, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(" interactively "));
        }

        [Test]
        public void VerifyEventualAdverbCredibly()
        {
            MoqUtil.SetupRandMock(17, 5, 9, 2, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(" credibly "));
        }

        [Test]
        public void VerifyEventualAdverbStrategically()
        {
            MoqUtil.SetupRandMock(17, 5, 9, 10, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(" strategically "));
        }

        [Test]
        public void VerifyEventualAdverbConservatively()
        {
            MoqUtil.SetupRandMock(17, 5, 9, 17, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(" conservatively "));
        }
    }
}
