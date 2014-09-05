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
            _defaults = new List<int> { 17, 7, 2, 8, 6, 11, 3, 5, 12};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        // Test first, last and all the complicated ones that call multiple other functions.

        [Test]
        public void VerifyGoingForward()
        {
            _defaults.Add(1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The stakeholders 24/7 avoid gaps going forward.", output);
        }

        [Test]
        public void VerifyBlankOutputForInvalidNumber()
        {
            _defaults.Add(222);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The stakeholders 24/7 avoid gaps.", output);
        }
    }
}
