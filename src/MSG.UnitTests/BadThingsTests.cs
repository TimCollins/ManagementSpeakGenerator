using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    /// <summary>
    /// Unit tests that verify the expected output from the GetBadThings() method.
    /// </summary>
    [TestFixture]
    class BadThingsTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> { 17, 8, 2, 8, 6, 11, 3, 5, 12, 8 };
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyExceptionThrownForInvalidInput()
        {
            _defaults.ReplaceAt(3, 50);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Assert.Throws<RandomNumberException>(() => DomainFactory.Generator.GetSentences(1));
        }

        [Test]
        public void VerifyIssuesOutput()
        {
            _defaults.ReplaceAt(7, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The stakeholders 24/7 avoid issues as part of the plan.", output);
        }
    }
}
