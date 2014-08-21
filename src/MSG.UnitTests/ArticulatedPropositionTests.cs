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
            _defaults.Insert(0, 20);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("; whereas "));
        }

        [Test]
        public void VerifyArticulatedPropositionGutFeeling()
        {
            _defaults.Insert(0, 21);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("our gut feeling is that "));
        }

        [Test]
        public void VerifyArticulatedPropositionWhile()
        {
            _defaults.Insert(0, 25);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(", while "));
        }

        [Test]
        public void VerifyArticulatedPropositionSameTime()
        {
            _defaults.Insert(0, 26);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(". At the same time, "));
        }

        [Test]
        public void VerifyArticulatedPropositionResult()
        {
            _defaults.Insert(0, 27);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(". As a result "));
        }

        [Test]
        public void VerifyArticulatedPropositionWhilst()
        {
            _defaults.Insert(0, 28);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(", whilst "));
        }
    }
}
