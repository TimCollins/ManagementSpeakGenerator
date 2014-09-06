using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class GrowthTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            //_defaults = new List<int> {10, 55, 1, 74, 2, 4, 22, 2, 5, 1, 25, 28, 5, 15, 10, 6, 6, 1, 2, 3, 4};
            _defaults = new List<int> { 10, 55, 1, 74, 22, 2, 5, 1, 25, 28, 5, 15, 10, 6, 6, 1, 2, 3, 4 };
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyExceptionThrownForInvalidSuperlative()
        {
            _defaults.Insert(4, 123);
            _defaults.Insert(5, 1);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            Assert.Throws<RandomNumberException>(() => DomainFactory.Generator.GetSentences(1));
        }

        [Test]
        public void VerifyExceptionThrownForInvalidImprovement()
        {
            _defaults.Insert(4, 1);
            _defaults.Insert(5, 123);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            Assert.Throws<RandomNumberException>(() => DomainFactory.Generator.GetSentences(1));
        }

        [Test]
        public void VerifyOrganicGrowth()
        {
            _defaults.Insert(4, 1);
            _defaults.Insert(5, 1);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("An organic growth credibly accelerates strong mobile strategies at the end of the day.", output);
        }

        [Test]
        public void VerifyUnprecedentedThroughputIncrease()
        {
            _defaults.Insert(4, 5);
            _defaults.Insert(5, 3);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("An unprecedented throughput increase credibly accelerates strong mobile strategies at the end of the day.", output);
        }

        [Test]
        public void VerifyUpperSingleDigitEfficiencyGain()
        {
            _defaults.Insert(4, 3);
            _defaults.Insert(5, 4);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("An upper single-digit efficiency gain credibly accelerates strong mobile strategies at the end of the day.", output);
        }

        [Test]
        public void VerifyProvenImprovement()
        {
            _defaults.Insert(4, 3);
            _defaults.Insert(5, 4);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("An upper single-digit efficiency gain credibly accelerates strong mobile strategies at the end of the day.", output);
        }

        [Test]
        public void VerifyMeasuredYieldEnhancement()
        {
            _defaults.Insert(4, 8);
            _defaults.Insert(5, 5);

            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("A measured yield enhancement credibly accelerates strong mobile strategies at the end of the day.", output);
        }
    }
}
