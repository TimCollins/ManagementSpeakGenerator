using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class FaukonTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int> {17, 5, 2, 1, 1, 1};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyFaukonNeedTo()
        {
            _defaults.Insert(2, 1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            List<string> output = DomainFactory.Generator.GetSentences(1);

            Assert.IsTrue(output[0].StartsWith("We need to "));
        }

        [Test]
        public void VerifyFaukonGotTo()
        {
            _defaults.Insert(2, 2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We've got to "));
        }

        [Test]
        public void VerifyFaukonUnitShould()
        {
            _defaults.Insert(2, 3);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            List<string> output = DomainFactory.Generator.GetSentences(1);

            Assert.IsTrue(output[0].StartsWith("The reporting unit should "));
        }

        [Test]
        public void VerifyFaukonControllingShould()
        {
            _defaults.Insert(2, 4);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("Controlling should "));
        }

        [Test]
        public void VerifyFaukonActivate()
        {
            _defaults.Insert(2, 5);
            _defaults.Add(1);
            _defaults.Add(1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We must activate "));
        }

        [Test]
        public void VerifyFaukonPursuing()
        {
            _defaults.Insert(2, 6);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("Pursuing this route will enable us to "));
        }

        [Test]
        public void VerifyFaukonExtraMile()
        {
            _defaults.Insert(2, 7);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We will go the extra mile to "));
        }

        [Test]
        public void VerifyFaukonWorkingHard()
        {
            _defaults.Insert(2, 8);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We are working hard to "));
        }

        [Test]
        public void VerifyFaukonTirelessly()
        {
            _defaults.Insert(2, 9);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.IsTrue(output.StartsWith("We continue to work tirelessly and diligently to "));
        }
    }
}
