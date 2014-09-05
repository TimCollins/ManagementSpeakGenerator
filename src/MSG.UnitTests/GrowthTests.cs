using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class GrowthTests
    {
        // Verify various combinations from GetGrowth.

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
        public void VerifyExceptionThrownForInvalidValue()
        {
            
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

    }
}
