using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class GetEventualPostfixedAdverbTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> { 17, 7, 2, 10, 23, 11, 3, 5, 12};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyGoingForward()
        {
            _defaults.Add(1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The partners diligently avoid gaps going forward.", output);
        }

        [Test]
        public void VerifyBlankOutputForInvalidNumber()
        {
            _defaults.Add(222);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The partners diligently avoid gaps.", output);
        }

        [Test]
        public void VerifyIndividualOutput()
        {
            _defaults.Add(33);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The partners diligently avoid gaps at the individual, team and organizational level.", output);
        }

        [Test]
        public void VerifyRandomArticle()
        {
            _defaults.Add(10);
            _defaults.Add(2);
            _defaults.Add(74);
            _defaults.Add(6);
            _defaults.Add(3);
            _defaults.Add(8);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The partners diligently avoid gaps using unparallelled throughput increase.", output);
        }

        [Test]
        public void VerifyRandomArticleAndThing()
        {
            _defaults.Add(12);
            _defaults.Add(2);
            _defaults.Add(74);
            _defaults.Add(6);
            _defaults.Add(3);
            _defaults.Add(8);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The partners diligently avoid gaps taking advantage of unparallelled throughput increase.", output);
        }

        [Test]
        public void VerifyMatrix()
        {
            _defaults.Add(13);
            _defaults.Add(2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The partners diligently avoid gaps within the organisation.", output);
        }

        [Test]
        public void VerifyEventualPlural()
        {
            _defaults.Add(14);
            _defaults.Add(2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The partners diligently avoid gaps across the organisations.", output);
        }

        [Test]
        public void VerifyGrowth()
        {
            _defaults.Add(18);
            _defaults.Add(3);
            _defaults.Add(4);
            _defaults.Add(6);
            _defaults.Add(3);
            _defaults.Add(8);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The partners diligently avoid gaps as a consequence of upper single-digit efficiency gain.", output);
        }

        [Test]
        public void VerifyPluralVerb()
        {
            _defaults.Add(19);
            _defaults.Add(3);
            _defaults.Add(4);
            _defaults.Add(6);
            _defaults.Add(3);
            _defaults.Add(8);
            _defaults.Add(2);
            _defaults.Add(7);
            _defaults.Add(5);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The partners diligently avoid gaps because the key, constructive, organizing principles produce proven yield enhancement.", output);

        }
    }
}
