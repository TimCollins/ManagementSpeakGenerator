using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class ArticulatedPropositionTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int>{5, 9, 10, 1, 1, 1, 1,
                                      5, 9, 10, 1, 1, 1, 1};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyArticulatedPropositionIsWhy()
        {
            _defaults.Insert(0, 18);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("; this is why "));
        }

        [Test]
        public void VerifyArticulatedPropositionNeverTheLess()
        {
            _defaults.Insert(0, 19);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("; nevertheless "));
        }

        [Test]
        public void VerifyArticulatedPropositionWhereas()
        {
            MoqUtil.SetupRandMock(20,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("; whereas "));
        }

        [Test]
        public void VerifyArticulatedPropositionGutFeeling()
        {
            MoqUtil.SetupRandMock(21,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("our gut feeling is that "));
        }

        [Test]
        public void VerifyArticulatedPropositionWhile()
        {
            MoqUtil.SetupRandMock(25,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(", while "));
        }

        [Test]
        public void VerifyArticulatedPropositionSameTime()
        {
            MoqUtil.SetupRandMock(26,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(". At the same time, "));
        }

        [Test]
        public void VerifyArticulatedPropositionResult()
        {
            MoqUtil.SetupRandMock(27,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(". As a result "));
        }

        [Test]
        public void VerifyArticulatedPropositionWhilst()
        {
            MoqUtil.SetupRandMock(28,   5, 9, 10, 1, 1, 1, 1,
                                        5, 9, 10, 1, 1, 1, 1);

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(", whilst "));
        }
    }
}
