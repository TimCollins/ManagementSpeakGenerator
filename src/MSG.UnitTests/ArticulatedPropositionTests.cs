using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class ArticulatedPropositionTests
    {
        [Test]
        public void VerifyArticulatedPropositionIsWhy()
        {
            MoqUtil.SetupRandMock(18,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("; this is why "));
        }

        [Test]
        public void VerifyArticulatedPropositionNeverTheLess()
        {
            MoqUtil.SetupRandMock(19,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("; nevertheless "));
        }

        [Test]
        public void VerifyArticulatedPropositionWhereas()
        {
            MoqUtil.SetupRandMock(20,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("; whereas "));
        }

        [Test]
        public void VerifyArticulatedPropositionGutFeeling()
        {
            MoqUtil.SetupRandMock(21,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains("our gut feeling is that "));
        }

        [Test]
        public void VerifyArticulatedPropositionWhile()
        {
            MoqUtil.SetupRandMock(25,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(", while "));
        }

        [Test]
        public void VerifyArticulatedPropositionSameTime()
        {
            MoqUtil.SetupRandMock(26,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(". At the same time, "));
        }

        [Test]
        public void VerifyArticulatedPropositionResult()
        {
            MoqUtil.SetupRandMock(27,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(". As a result "));
        }

        [Test]
        public void VerifyArticulatedPropositionWhilst()
        {
            MoqUtil.SetupRandMock(28,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            MoqUtil.UndoMockRandomNumber();

            Assert.IsTrue(output.Contains(", whilst "));

        }
    }
}
