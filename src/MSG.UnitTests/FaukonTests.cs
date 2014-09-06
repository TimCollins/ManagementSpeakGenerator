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

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We need to credibly streamline the process going forward.", output);
        }

        [Test]
        public void VerifyFaukonGotTo()
        {
            _defaults.Insert(2, 2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We've got to credibly streamline the process going forward.", output);
        }

        [Test]
        public void VerifyFaukonUnitShould()
        {
            _defaults.Insert(2, 3);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("The reporting unit should credibly streamline the process going forward.", output);
        }

        [Test]
        public void VerifyFaukonControllingShould()
        {
            _defaults.Insert(2, 4);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("Controlling should credibly streamline the process going forward.", output);
        }

        [Test]
        public void VerifyFaukonActivate()
        {
            _defaults.Insert(2, 5);
            _defaults.Add(1);
            _defaults.Add(1);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We must activate the organisation to interactively streamline the process going forward.", output);
        }

        [Test]
        public void VerifyFaukonPursuing()
        {
            _defaults.Insert(2, 6);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("Pursuing this route will enable us to credibly streamline the process going forward.", output  );
        }

        [Test]
        public void VerifyFaukonExtraMile()
        {
            _defaults.Insert(2, 7);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We will go the extra mile to credibly streamline the process going forward.", output);
        }

        [Test]
        public void VerifyFaukonWorkingHard()
        {
            _defaults.Insert(2, 8);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We are working hard to credibly streamline the process going forward.", output);
        }

        [Test]
        public void VerifyFaukonTirelessly()
        {
            _defaults.Insert(2, 9);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to credibly streamline the process going forward.", output);
        }
    }
}
