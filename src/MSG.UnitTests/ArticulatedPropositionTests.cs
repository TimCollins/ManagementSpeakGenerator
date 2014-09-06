using System.Collections.Generic;
using MSG.DomainLogic;
using NUnit.Framework;

namespace MSG.UnitTests
{
    [TestFixture]
    class ArticulatedPropositionTests
    {
        private List<int> _defaults;

        [SetUp]
        public void SetUpDefaultNumbers()
        {
            _defaults = new List<int>{5, 9, 10, 1, 1, 1, 1,
                                      5, 9, 10, 1, 1, 1, 1};
        }

        [TearDown]
        public void UndoRandomNumberSetting()
        {
            MoqUtil.UndoMockRandomNumber();
        }

        [Test]
        public void VerifyArticulatedProposition()
        {
            _defaults.Insert(0, 6);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward.", output);
        }

        [Test]
        public void VerifyArticulatedPropositionIsWhy()
        {
            _defaults.Insert(0, 18);
            _defaults.Insert(2, 7);
            _defaults.Remove(2);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We will go the extra mile to technically streamline the process going forward; this is why we need to 200% think across the full value chain going forward.", output);
        }

        [Test]
        public void VerifyArticulatedPropositionNevertheless()
        {
            _defaults.Insert(0, 19);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward; nevertheless we must activate the matrix to strategically streamline the process going forward.", output);
        }

        [Test]
        public void VerifyArticulatedPropositionWhereas()
        {
            _defaults.Insert(0, 20);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward; whereas we must activate the matrix to strategically streamline the process going forward.", output);
        }

        [Test]
        public void VerifyArticulatedPropositionGutFeeling()
        {
            _defaults.Insert(0, 21);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("Our gut feeling is that we continue to work tirelessly and diligently to strategically streamline the process going forward.", output);
        }

        [Test]
        public void VerifyArticulatedPropositionWhile()
        {
            _defaults.Insert(0, 25);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward, while we must activate the matrix to strategically streamline the process going forward.", output);
        }

        [Test]
        public void VerifyArticulatedPropositionSameTime()
        {
            _defaults.Insert(0, 26);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward. At the same time, we must activate the matrix to strategically streamline the process going forward.", output);
        }

        [Test]
        public void VerifyArticulatedPropositionResult()
        {
            _defaults.Insert(0, 27);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward. As a result we must activate the matrix to strategically streamline the process going forward.", output);
        }

        [Test]
        public void VerifyArticulatedPropositionWhilst()
        {
            _defaults.Insert(0, 28);
            MoqUtil.SetupRandMock(_defaults.ToArray());
            string output = DomainFactory.Generator.GetSentences(1)[0];

            Assert.AreEqual("We continue to work tirelessly and diligently to strategically streamline the process going forward, whilst we must activate the matrix to strategically streamline the process going forward.", output);
        }

        [Test]
        public void VerifyExceptionThrown()
        {
            _defaults.Insert(0, 555);
            MoqUtil.SetupRandMock(_defaults.ToArray());

            Assert.Throws<RandomNumberException>(() => DomainFactory.Generator.GetSentences(1));
        }
    }
}
