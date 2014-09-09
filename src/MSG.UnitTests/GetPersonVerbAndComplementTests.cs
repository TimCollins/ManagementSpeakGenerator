using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class GetPersonVerbAndComplementTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> {0, 17, 5, 9, 10, 7, 3};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyInvalidValueHandled()
        {
            _defaults.Insert(6, 888);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Assert.Throws<RandomNumberException>(() => DomainFactory.Generator.GetSentences(1));
        }

        [Test]
        public void VerifyStreamline()
        {
            _defaults.Insert(6, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process across the board.", output);
        }

        [Test]
        public void VerifyPortfolio()
        {
            _defaults.Insert(6, 3);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically benchmark the portfolio across the board.", output);
        }

        [Test]
        public void VerifyOutsideTheBox()
        {
            _defaults.Insert(6, 8);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically think outside the box across the board.", output);
        }

        [Test]
        public void VerifyDownside()
        {
            _defaults.Insert(6, 34);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically manage the downside across the board.", output);
        }

        [Test]
        public void VerifyStatusQuo()
        {
            _defaults.Insert(6, 48);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically challenge the status quo across the board.", output);
        }

        [Test]
        public void VerifyPriorities()
        {
            _defaults.Insert(6, 60);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically execute on priorities across the board.", output);
        }
    }
}
