using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class PropositionSemiColonTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> {0, 100, 230, 23, 22, 203, 71, 75, 2, 63, 4, 2, 70, 57, 2, 85, 119, 110, 13, 20, 1, 80, 12, 2, 104};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }


        [Test]
        public void SemiColonPlacement18()
        {
            _defaults.Insert(1, 18);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("Performance, leverage and time-phase drive the human resources; this is why innovations efficiently influence the group.", output);
        }

        [Test]
        public void SemiColonPlacement19()
        {
            _defaults.Insert(1, 19);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];
            
            Assert.AreEqual("Performance, leverage and time-phase drive the human resources; nevertheless innovations efficiently influence the group.", output);
        }

        [Test]
        public void SemiColonPlacement20()
        {
            _defaults.Insert(1, 20);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("Performance, leverage and time-phase drive the human resources; whereas innovations efficiently influence the group.", output);
        }

        [Test]
        public void SemiColonPlacement25()
        {
            _defaults.Insert(1, 25);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("Performance, leverage and time-phase drive the human resources, while innovations efficiently influence the group.", output);
        }

        [Test]
        public void SemiColonPlacement26()
        {
            _defaults.Insert(1, 26);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("Performance, leverage and time-phase drive the human resources. At the same time, innovations efficiently influence the group.", output);
        }

        [Test]
        public void SemiColonPlacement27()
        {
            _defaults.Insert(1, 27);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("Performance, leverage and time-phase drive the human resources. As a result innovations efficiently influence the group.", output);
        }

        [Test]
        public void SemiColonPlacement28()
        {
            _defaults.Insert(1, 28);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("Performance, leverage and time-phase drive the human resources, whilst innovations efficiently influence the group.", output);
        }
    }
}
