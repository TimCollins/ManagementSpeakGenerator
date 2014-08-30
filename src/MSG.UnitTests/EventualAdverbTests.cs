using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class EventualAdverbTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> {17, 5, 9, 1, 1, 1};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyEventualAdverbInteractively()
        {
            _defaults.Insert(3, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(" interactively "));
        }

        [Test]
        public void VerifyEventualAdverbCredibly()
        {
            _defaults.Insert(3, 2);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(" credibly "));
        }

        [Test]
        public void VerifyEventualAdverbStrategically()
        {
            _defaults.Insert(3, 10);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(" strategically "));
        }

        [Test]
        public void VerifyEventualAdverbConservatively()
        {
            _defaults.Insert(3, 17);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains(" conservatively "));
        }
    }
}
