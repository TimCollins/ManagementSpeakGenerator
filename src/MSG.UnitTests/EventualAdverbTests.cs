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
            _defaults = new List<int> {0, 17, 5, 9, 1, 1, 1};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyEventualAdverbInteractively()
        {
            _defaults.Insert(4, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to interactively streamline the process going forward.", output);
        }

        [Test]
        public void VerifyEventualAdverbCredibly()
        {
            _defaults.Insert(4, 2);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to credibly streamline the process going forward.", output);
        }

        [Test]
        public void VerifyEventualAdverbStrategically()
        {
            _defaults.Insert(4, 10);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward.", output);
        }

        [Test]
        public void VerifyEventualAdverbConservatively()
        {
            _defaults.Insert(4, 17);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to conservatively streamline the process going forward.", output);
        }
    }
}
