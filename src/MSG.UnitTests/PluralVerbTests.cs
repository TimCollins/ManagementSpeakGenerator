using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class PluralVerbTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> { 17, 5, 1, 8, 1, 11, 1, 1, 1 };
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyIdentifies()
        {
            _defaults.Insert(6, 2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("identifies"));
        }

        [Test]
        public void VerifyAvoids()
        {
            _defaults.Insert(6, 3);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("avoids"));
        }

        [Test]
        public void VerifyMitigates()
        {
            _defaults.Insert(6, 4);
            MoqUtil.SetupRandMock(_defaults.ToArray());


            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.Contains("mitigates"));
        }
    }
}
