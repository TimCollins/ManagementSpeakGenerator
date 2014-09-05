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
            _defaults = new List<int> { 17, 5, 9, 10, 7, 3};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyInvalidValueHandled()
        {
        }

        [Test]
        public void VerifyStreamlines()
        {
            _defaults.Insert(5, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process across the board.", output);
        }

        [Test]
        public void VerifyPortfolio()
        {
            
        }

        [Test]
        public void VerifyOutsideTheBox()
        {
            
        }

        [Test]
        public void VerifyDownside()
        {
            // 34
        }

        [Test]
        public void VerifyStatusQuo()
        {
            // 48
        }

        [Test]
        public void VerifyPriorities()
        {
            // 60
        }

    }
}
