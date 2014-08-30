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
        public void VerifyArticulatedProposition()
        {
            _defaults.Insert(0, 6);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We continue to"));
            Assert.IsTrue(output.Contains("tirelessly and diligently"));
            Assert.IsTrue(output.EndsWith("."));
        }

        [Test]
        public void VerifyArticulatedPropositionIsWhy()
        {
            _defaults.Insert(0, 18);
            _defaults.Insert(2, 7);
            _defaults.Remove(2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We will go"));
            Assert.IsTrue(output.Contains("; this is why "));
            Assert.IsTrue(output.EndsWith("."));
        }

        [Test]
        public void VerifyArticulatedPropositionNevertheless()
        {
            _defaults.Insert(0, 19);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We continue to"));
            Assert.IsTrue(output.Contains("; nevertheless "));
            Assert.IsTrue(output.EndsWith("."));
        }

        [Test]
        public void VerifyArticulatedPropositionWhereas()
        {
            _defaults.Insert(0, 20);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We continue to"));
            Assert.IsTrue(output.Contains("; whereas "));
            Assert.IsTrue(output.EndsWith("."));
        }

        [Test]
        public void VerifyArticulatedPropositionGutFeeling()
        {
            _defaults.Insert(0, 21);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("Our gut feeling is that "));
            Assert.IsTrue(output.EndsWith("."));
        }

        [Test]
        public void VerifyArticulatedPropositionWhile()
        {
            _defaults.Insert(0, 25);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We continue to"));
            Assert.IsTrue(output.Contains(", while "));
            Assert.IsTrue(output.EndsWith("."));
        }

        [Test]
        public void VerifyArticulatedPropositionSameTime()
        {
            _defaults.Insert(0, 26);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We continue to"));
            Assert.IsTrue(output.Contains(". At the same time, "));
            Assert.IsTrue(output.EndsWith("."));
        }

        [Test]
        public void VerifyArticulatedPropositionResult()
        {
            _defaults.Insert(0, 27);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We continue to"));
            Assert.IsTrue(output.Contains(". As a result "));
            Assert.IsTrue(output.EndsWith("."));
        }

        [Test]
        public void VerifyArticulatedPropositionWhilst()
        {
            _defaults.Insert(0, 28);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We continue to"));
            Assert.IsTrue(output.Contains(", whilst "));
            Assert.IsTrue(output.EndsWith("."));
        }
    }
}
