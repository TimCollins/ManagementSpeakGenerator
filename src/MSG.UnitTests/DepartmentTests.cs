using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class DepartmentTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int>{17, 6, 1, 17, 2, 1, 4, 7, 5, 1, 3, 2};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyHumanResourcesSpacing()
        {
            _defaults.Insert(7, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The Group Chief Human Resources Officer globally streamlines the process across the board.", output);
        }

        [Test]
        public void VerifyCustomerRelationsSpacing()
        {
            _defaults.Insert(7, 7);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The Group Chief Customer Relations Officer globally streamlines the process across the board.", output);
        }

        [Test]
        public void VerifyMarketingSpacing()
        {
            _defaults.Insert(7, 14);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The Group Chief Marketing Officer globally streamlines the process across the board.", output);
        }

        [Test]
        [ExpectedException(typeof(RandomNumberException))]
        public void VerifyInvalidValueHandled()
        {
            _defaults.Insert(7, 50);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            DomainFactory.Generator.GetSentences(1);
        }
    }
}
